using Hotel.main.entity;
using Hotel.main.services.CustomerServices;
using Hotel.main.services.HotelServices;
using Hotel.main.services.ReservationServices;
using Hotel.main.services.RoomServices;
using Hotel.main.utils;

namespace Hotel.main;

public static class Program
{
    private static Customer _customer = new();
    private static Customer _client = new();
    private static List<entity.Hotel> _hotels = new();
    private static List<Reservation> _reservation = new();

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║              ¡ Bienvenido al Hotel!                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.WriteLine("Legajo Sugerido a Ingresar: 882831");
            GetEmployee();
            if (ValidateInput.ValidateBoolean("Es un Cliente nuevo? (Si / No): "))
            {
                NewData();
            }
            else
            {
                Console.WriteLine("Legajo Sugerido de Usuario: 888086");
                GetAllDataClient();
            }

            var session = true;
            while (session)
            {
                var main = MenuMain();
                session = main != 0 && SwitchMenu(main, MenuOptions());

                Console.Clear();
            }
        }
    }

    private static void NewData()
    {
        _client = new S_CustomerCreate().NewCustomer();
    }

    private static void GetEmployee()
    {
        _customer = new S_Customer().SelectCustomer("Ingrese su número de legajo: ");
    }

    private static void GetAllDataClient()
    {
        _client = new S_Customer().SelectCustomer("Ingrese el Legajo del Usuario a tratar: ");
        GetData();
    }

    private static void GetData()
    {
        _reservation = new S_Reservation().GetReservationsData(_client.usuario);
        _hotels = new S_Hotel().GetHotelesData(_client.usuario);
    }

    private static int GetRecord(string text)
    {
        return ValidateInput.ValidateInteger(text);
    }

    private static int MenuMain()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   Menú Principal                   ║");
        Console.WriteLine("╠════════════════════════════════════════════════════╣");
        Console.WriteLine("║     1. Crear                                       ║");
        Console.WriteLine("║     2. Listado                                     ║");
        Console.WriteLine("║     3. Modificar                                   ║");
        // Console.WriteLine("║     4. Borrar                                      ║");
        Console.WriteLine("║     0. Cerrar sesión                               ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 4, true);
    }

    private static int MenuOptions()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║                       Opciones                     ║");
        Console.WriteLine("╠════════════════════════════════════════════════════╣");
        Console.WriteLine("║     1. Usuario                                     ║");
        Console.WriteLine("║     2. Reservas                                    ║");
        Console.WriteLine("║     3. Hoteles                                     ║");
        Console.WriteLine("║     4. Habitaciones                                ║");
        Console.WriteLine("║     0. Volver al Menú Principal                    ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 5, true);
    }

    private static bool SwitchMenu(int menu, int ops)
    {
        switch (menu)
        {
            case 1: // Crear
                SwitchCreate(ops);
                break;
            case 2: // Consultar
                SwitchView(ops);
                break;
            case 3: // Modificar
                SwitchModify(ops);
                break;
            // case 4: // Borrar
            //     SwitchDelete(ops);
            //     break;
            default: //Salir
                // Console.Clear();
                // Environment.Exit(1);
                return false;
        }

        return true;
    }

    private static void SwitchCreate(int ops)
    {
        switch (ops)
        {
            case 1: // Usuario
                new S_CustomerCreate().NewCustomer();
                break;
            case 2: // Reserva
                var r = new S_ReservationCreate().NewReservation(_client);
                if (!string.IsNullOrEmpty(r.fechaEgreso))
                {
                    GetData();
                }

                break;
            case 3: // Hotel
                new S_HotelCreate().NewHotel(_customer);
                break;
            case 4: // Habitacion
                new S_RoomCreate().NewHotel(_customer);
                break;
            default: // Salir
                Console.Clear();
                break;
        }
    }

    private static void SwitchView(int ops)
    {
        switch (ops)
        {
            case 1: // Usuario
                new S_CustomerView().ViewCustomer(_client);
                break;
            case 2: // Reserva
                new S_ReservationView().ViewReservation(_reservation);
                break;
            case 3: // Hotel
                new S_HotelView().HotelView(_hotels);
                break;
            case 4: // Habitacion
                new S_RoomView().ViewRoom(_hotels, _reservation);
                break;
            default: // Salir
                Console.Clear();
                break;
        }
    }

    private static void SwitchModify(int ops)
    {
        switch (ops)
        {
            case 1: // Usuario
                new S_CustomerModify().ModifyCustomer(_client);
                break;
            case 2: // Reserva
                if (_reservation.Count > 0) new S_ReservationModify().ModifyReservation(_reservation);
                else Console.WriteLine("No se encuentran reservas registradas!");
                Comment.StopToThink();
                break;
            case 3: // Hotel
                if (_hotels.Count > 0) new S_HotelModifiy().HotelModify(_hotels);
                else Console.WriteLine("No se encuentran hoteles registrados para a su usuario");
                Comment.StopToThink();
                break;
            case 4: // 
                if (_hotels.Count > 0) new S_RoomModify().RoomMenuModify(_hotels, _reservation);
                else Console.WriteLine("No se encuentran hoteles registrados para a su usuario");
                Comment.StopToThink();
                break;
            default: // Salir
                Console.Clear();
                break;
        }
    }

    private static void SwitchDelete(int ops)
    {
        // TODO: Hacer la eliminacion (No entraba segun lo hablado)
        switch (ops)
        {
            case 1: // Usuario
                new S_CustomerDelete().DeleteCustomerData(_client);
                break;
            case 2: // Reserva
                new S_ReservationDelete().DeleteReservationsData(_reservation[0]);
                break;
            case 3: // Hotel
                new S_HotelDelete().DeleteHotelesData(_hotels[0]);
                break;
            case 4: // Habitacion
                new S_RoomDelete().DeleteRoomData(new Room());
                break;
            default: // Salir
                Console.Clear();
                break;
        }
    }
}