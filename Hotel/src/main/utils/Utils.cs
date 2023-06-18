namespace Hotel.main.utils;

public static class Utils
{
    public static string DateTimeFormatter(string dt, string format = "yyyy-MM-ddTHH:mm:ss")
    {
        return DateTime.ParseExact(dt, format, System.Globalization.CultureInfo.InvariantCulture)
            .ToString("dd-MM-yyyy");
    }

    public static string DateTimeFormatter(DateTime dt, string format = "yyyy-MM-ddTHH:mm:ss")
    {
        return DateTimeFormatter(dt.ToString(format), format);
    }
}