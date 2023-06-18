using System.Globalization;
using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.utils;

namespace Hotel.main.services.ReservationServices;

public class S_ReservationView
{
    public void ViewReservation(List<Reservation> r)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            Console.WriteLine("══════════════════════════════════════════════════════");
            foreach (var reservation in r)
            {
                ShowDataReservation(reservation);
            }

            opt = !Comment.StopToThink();
        }
    }

    private void ShowData()
    {
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Detalle Reservas                  ");
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private static void ShowDataReservation(Reservation r)
    {
        Console.WriteLine(r.ToReport());
        Console.WriteLine("══════════════════════════════════════════════════════");
    }
}