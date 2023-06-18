using Hotel.main.dao;
using Utils;

namespace Hotel.main.services.HotelServices;

public class S_HotelView
{
    public void HotelView(List<entity.Hotel> h)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            foreach (var hotel in h)
            {
                ShowDataHotel(hotel);
            }

            opt = !Comment.StopToThink();
        }
    }

    private void ShowData()
    {
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Detalle Hotel                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private static void ShowDataHotel(entity.Hotel h)
    {
        Console.WriteLine(h.ToReport());
        Console.WriteLine("══════════════════════════════════════════════════════");
    }
    
}