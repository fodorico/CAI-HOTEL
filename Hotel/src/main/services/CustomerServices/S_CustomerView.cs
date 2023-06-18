using Hotel.main.entity;
using Utils;

namespace Hotel.main.services.CustomerServices;

public class S_CustomerView
{
    public void ViewCustomer(Customer c)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData(c);
            opt = !Comment.StopToThink();
        }
    }

    private void ShowData(Customer c)
    {
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Detalle Cliente                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine(c.ToReport());
        Console.WriteLine("══════════════════════════════════════════════════════");
    }
}