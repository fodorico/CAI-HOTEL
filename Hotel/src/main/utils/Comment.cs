namespace Utils;

public static class Comment
{
    public static bool StopToThink()
    {
        Console.WriteLine("Si desea contunuar toque una tecla....");
        Console.ReadKey();
        return true;
    }
}