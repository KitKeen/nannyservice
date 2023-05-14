using System.Text;
using CoffieNanny.Extentions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace nannyservice;

public static class MessageBrocker
{
    static MessageBrocker()
    {
        
    }

    public static void ConnectToBrocker(string user, string password, string hostName, string port, string vhost)
    {
        ConnectionFactory factory = new ConnectionFactory
        {
            AutomaticRecoveryEnabled = true,
            NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
        };

        if (user.IsNullOrWhitespace())
            user = "guest";

        if (password.IsNullOrWhitespace())
            password = "guest";

        if (hostName.IsNullOrWhitespace())
            hostName = "localhost";

        if (port.IsNullOrWhitespace())
            port = "5672";
        
        if (vhost.IsNullOrWhitespace())
            vhost = "/";
        
        factory.Uri = new Uri($"amqp://{user}:{password}@{hostName}:{port}/{vhost}");

        var exchangeName = "FirstExchange";
        var queueName = "FirstQueue";
        var routingKey = "simple_example_of_routing_key";

        using IConnection connection = factory.CreateConnection();
        using IModel channel = connection.CreateModel();
        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
        channel.QueueDeclare(queueName, false, false, false, null);
        channel.QueueBind(queueName, exchangeName, routingKey, null);

        byte[] messageFromBody = "Hello world"u8.ToArray();
        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "text/plain";
        props.DeliveryMode = 2;
        props.Headers.Add("latitude",  51.5252949);
        props.Headers.Add("longitude", -0.0905493);
        props.Expiration = "36000000";
        channel.BasicPublish(exchangeName, routingKey, null, messageFromBody);
        
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (ch, ea) =>
        {
            var body = ea.Body.ToArray();
            channel.BasicAck(ea.DeliveryTag, false);
        };

        string consumerTag = channel.BasicConsume(queueName, false, consumer);
    }
}