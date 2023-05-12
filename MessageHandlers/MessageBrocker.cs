using CoffieNanny.Extentions;
using RabbitMQ.Client;

namespace nannyservice;

public static class MessageBrocker
{
    static MessageBrocker()
    {
        
    }

    public static void ConnectToBrocker(string user, string password, string hostName, string port, string vhost)
    {
        ConnectionFactory factory = new ConnectionFactory();

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

        using IConnection connection = factory.CreateConnection();
        using (IModel channel = connection.CreateModel())
        {
            
        }
    }
}