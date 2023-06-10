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
        // Preguntar si es nuevo usuario o si es usuario ya creado.
        UploadData();
        while (true)
        {
            SwitchMainMenu(Menu());
            Console.Clear();
        }
    }

    private static void UploadData()
    {
        // Legajo --> 854851
        _cliente = new S_Cliente().GetClientData(GetLegajo());
        _cliente.usuario = "888086";
        _reservas = new S_Reserva().GetReservasData(_cliente.usuario);
        _hotels = new S_Hotel().GetHotelesData(_cliente.usuario);
    }

    private static int GetLegajo()
    {
        return ValidateInput.ValidateInteger("Ingrese su número de legajo: ");
    }

    private static int Menu()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   Menú Principal                   ║");
        Console.WriteLine("╠════════════════════════════════════════════════════╣");
        Console.WriteLine("║     1. Datos del Cliente                           ║");
        Console.WriteLine("║     2) Menú de su Reserva                          ║");
        Console.WriteLine("║     0. Salir                                       ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 3, true);
    }

    private static int MenuReserva()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   Menú Reserva                     ║");
        Console.WriteLine("╠════════════════════════════════════════════════════╣");
        Console.WriteLine("║     1) Datos de su Reservas                        ║");
        Console.WriteLine("║     2) Datos de su Hoteles Reservados              ║");
        Console.WriteLine("║     3) Datos de su Habitaciones Reservadas         ║");
        Console.WriteLine("║     0. Salir                                       ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 4, true);
    }

    private static void SwitchMainMenu(int menu)
    {
        switch (menu)
        {
            case 1: // Datos del Cliente
                new S_ClienteMenu().ClienteMenuModificar(_cliente);
                break;
            case 2: // Menú de su Reserva
                SwitchMenuReserva(MenuReserva());
                break;
            default: //Salir
                Console.Clear();
                Environment.Exit(1);
                break;
        }
    }

    private static void SwitchMenuReserva(int menu)
    {
        switch (menu)
        {
            case 1: // Datos de sus Reservas
                if (_reservas.Count > 0) new S_ReservaMenu().ReservaMenu(_reservas);
                else Console.WriteLine("No se encuentran reservas registradas!");
                break;
            case 2: // Datos de sus Hoteles
                if (_hotels.Count > 0) new S_HotelMenu().HotelMenu(_hotels);
                else Console.WriteLine("No se encuentran hoteles registrados para esa reserva");
                break;
            case 3: // Datos de sus Habitaciones
                if (_hotels.Count > 0) new S_HabitacionMenu().HabitacionMenu(_hotels, _reservas);
                else Console.WriteLine("No se encuentran hoteles registrados para esa reserva");
                break;
            default: // Salir
                Console.Clear();
                Environment.Exit(1);
                break;
        }
    }
}