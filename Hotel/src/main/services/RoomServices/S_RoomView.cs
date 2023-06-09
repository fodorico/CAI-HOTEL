using Hotel.main.entity;
using Hotel.main.utils;

namespace Hotel.main.services.RoomServices;

public class S_RoomView
{
    public void ViewRoom(List<entity.Hotel> h, List<Reservation> r)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            var listRoom = new S_Room().GetSpecificRooms(h, r);
            Console.WriteLine("══════════════════════════════════════════════════════");
            foreach (var room in listRoom)
            {
                ShowDataRoom(room);
            }

            opt = !Comment.StopToThink();
        }
    }

    private void ShowData()
    {
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Detalle Habitación                ");
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("Aguarde, se está cargando la información.");
    }

    public void ShowDataRoom(Room h)
    {
        Console.WriteLine(h.ToReport());
        Console.WriteLine("══════════════════════════════════════════════════════");
    }
}