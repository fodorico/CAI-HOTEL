namespace Hotel.main.utils;

public static class Comment
{
    private const string WaitMessage = "Si desea continuar toque una tecla....";
    public static bool StopToThink(string text = WaitMessage)
    {
        Console.WriteLine(text);
        Console.ReadKey();
        return true;
    }
}