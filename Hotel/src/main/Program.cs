using Hotel.main.entity;
using Hotel.main.services.CustomerServices;
using Hotel.main.services.HotelServices;
using Hotel.main.services.ReservationServices;
using Hotel.main.services.RoomServices;
using Utils;

namespace Hotel.main;

public static class Program
{
    private static Customer _customer = new();
    private static List<entity.Hotel> _hotels = new();
    private static List<Reservation> _reservation = new();

    public static void Main()
    {
        Console.WriteLine($"Bienvenido!!");
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║                  ¡ Bienvenido !                    ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        // if (ValidateInput.ValidateBoolean("Usted es un nuevo usuario? (SI / NO): "))
        // {
        //     NewData();
        // }
        // else
        // {
        UploadData();
        // }

        while (true)
        {
            SwitchMenu(MenuMain(), MenuOptions());
            Console.Clear();
        }
    }

    private static void NewData()
    {
        _customer = new S_CustomerCreate().NewCustomer();
        _reservation = new List<Reservation>();
        _hotels = new List<entity.Hotel>();
    }

    private static void UploadData()
    {
        // _customer = new S_Customer().GetCustomerData(GetRecord());
        _customer = new S_Customer().GetCustomerData(882831);
        _customer.usuario = "888086";
        _reservation = new S_Reservation().GetReservationsData(_customer.usuario);
        _hotels = new S_Hotel().GetHotelesData(_customer.usuario);
    }

    private static int GetRecord()
    {
        return ValidateInput.ValidateInteger("Ingrese su número de legajo: ");
    }

    private static int MenuMain()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   Menú Principal                   ║");
        Console.WriteLine("╠════════════════════════════════════════════════════╣");
        Console.WriteLine("║     1. Crear                                       ║");
        Console.WriteLine("║     2. Consultar                                   ║");
        Console.WriteLine("║     3. Modificar                                   ║");
        // Console.WriteLine("║     4. Modificar                                   ║");
        Console.WriteLine("║     0. Salir                                       ║");
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
        Console.WriteLine("║     0. Salir                                       ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 5, true);
    }

    private static void SwitchMenu(int menu, int ops)
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
                Console.Clear();
                Environment.Exit(1);
                break;
        }
    }

    private static void SwitchCreate(int ops)
    {
        switch (ops)
        {
            case 1: // Usuario
                new S_CustomerCreate().NewCustomer();
                break;
            case 2: // Reserva
                new S_ReservationCreate().NewReservation(_customer);
                break;
            case 3: // Hotel
                new S_HotelCreate().NewHotel(_customer);
                break;
            case 4: // Habitacion
                // TODO: Falta crear Habitaciones
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
                new S_CustomerView().ViewCustomer(_customer);
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
                new S_CustomerModify().ModifyCustomer(_customer);
                break;
            case 2: // Reserva
                new S_ReservationModify().ModifyReserva(_reservation);
                break;
            case 3: // Hotel
                new S_HotelModifiy().HotelModify(_hotels);
                break;
            case 4: // Habitacion
                new S_RoomModify().RoomMenuModify(_hotels, _reservation);
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
                new S_CustomerDelete().DeleteCustomerData(_customer);
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