namespace Hotel.main.utils;

public static class Utils
{
    private const string DefaultFormat = "yyyy-MM-ddTHH:mm:ss";

    public static string DateTimeFormatter(string dt, string format = DefaultFormat)
    {
        return DateTime.ParseExact(dt, format, System.Globalization.CultureInfo.InvariantCulture)
            .ToString("dd-MM-yyyy");
    }

    public static string DateTimeFormatter(DateTime dt, string format = DefaultFormat)
    {
        return DateTimeFormatter(dt.ToString(format), format);
    }

    public static bool Exit()
    {
        Console.Clear();
        Console.WriteLine("Gracias por usar nuestro servicio! Toque cualquier tecla para finalizar.");
        Environment.Exit(1);
        return false;
    }
}