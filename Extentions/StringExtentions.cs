namespace CoffieNanny.Extentions;

public static class StringExtentions
{
    public static bool IsNullOrWhitespace(this string str)
        => string.IsNullOrWhiteSpace(str);

    public static bool IsNotNullOrWhitespace(this string str)
        => !string.IsNullOrWhiteSpace(str);
}