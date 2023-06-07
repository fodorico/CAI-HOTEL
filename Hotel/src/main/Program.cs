using Hotel.main.entity;
using Hotel.main.services;
using Utils;

namespace Hotel.main;

public class Program
{
    private static Cliente _cliente;
    private static List<entity.Hotel> _hotels;
    private static List<Reserva> _reservas;

    public static void Main()
    {
        Console.WriteLine($"Bienvenido!!");
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║                  ¡ Bienvenido !                    ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        UploadData();
        while (true)
        {
            SwitchMainMenu(Menu());
            Console.Clear();
        }
    }

    private static int GetLegajo()
    {
        return ValidateInput.ValidateInteger("Ingrese su número de legajo: ");
    }

    private static void UploadData()
    {// Legajo --> 854851
        _cliente = new S_Cliente().GetClientData(GetLegajo());
        _cliente.usuario = "888086";
        _hotels = new S_Hotel().GetHotelesData(_cliente.usuario);
        _reservas = new S_Reserva().GetReservasData(_cliente.usuario);
    }

    private static int Menu()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   Menú Principal                   ║");
        Console.WriteLine("╠════════════════════════════════════════════════════╣");
        Console.WriteLine("║     1. Datos del Cliente                           ║");
        Console.WriteLine("║     2) Datos de una Reserva                        ║");
        Console.WriteLine("║     3) Datos de sus Reservas                       ║");
        Console.WriteLine("║     4) Datos de un Hotel Reservado                 ║");
        Console.WriteLine("║     5) Datos de sus Hoteles Reservados             ║");
        Console.WriteLine("║     6) Datos de una Habitación Reservada           ║");
        Console.WriteLine("║     7) Datos de sus Habitaciones Reservadas        ║");
        Console.WriteLine("║     0. Salir                                       ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 8, true);
    }

    private static void SwitchMainMenu(int menu)
    {
        switch (menu)
        {
            case 1:
                new S_ClienteMenu().ClienteMenu(_cliente);
                break;
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            default:
                Console.Clear();
                Environment.Exit(1);
                break;
        }
    }
}