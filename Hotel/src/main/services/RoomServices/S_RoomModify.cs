using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.utils;

namespace Hotel.main.services.RoomServices;

public class S_RoomModify
{
    public void RoomMenuModify(List<entity.Hotel> h, List<Reservation> r)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            opt = SwitchAndValidate(new S_Room().GetSpecificRooms(h, r));
        }
    }


    private bool SwitchAndValidate(List<Room> h)
    {
        Room hab;
        while (true)
        {
            var cod = ValidateInput.ValidateInteger(
                "Por favor escriba el Código de la Habitacion que desea modificar: ", 0,
                999, true);
            hab = h.FirstOrDefault(t => t.id == cod);
            if (hab != null)
            {
                break;
            }

            Console.WriteLine("Por favor coloque un código valido!");
        }

        return SwitchMenuRoom(ShowMenuRoom(), hab);
    }

    private int ShowMenuRoom()
    {
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Menú Habitacion                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("¿Qué datos le gustaría modificar?");
        Console.WriteLine("     1. Cantidad Plazas");
        Console.WriteLine("     2. Categoria");
        Console.WriteLine("     3. Precio");
        Console.WriteLine("     4. Cancelable");
        Console.WriteLine("     0. Salir");
        Console.WriteLine("══════════════════════════════════════════════════════");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 5, true);
    }

    private bool SwitchMenuRoom(int i, Room r)
    {
        switch (i)
        {
            case 1:
                SetNewQuantitySpaces(r);
                break;
            case 2:
                SetNewCategory(ref r);
                break;
            case 3:
                SetNewPrice(ref r);
                break;
            case 4:
                SetNewCancelable(ref r);
                break;
            default:
                return false;
        }

        new D_Room().Update(r);
        return false;
    }

    private static void SetNewQuantitySpaces(Room r)
    {
        var tempCP = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Plazas: ");
        r.cantidadPlazas = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
            ? tempCP
            : r.cantidadPlazas;
    }

    private static void SetNewCategory(ref Room r)
    {
        var tempC = ValidateInput.ValidateString("Ingrese la nueva Categoria: ", "IsLetter");
        r.categoria = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempC : r.categoria;
    }

    private static void SetNewPrice(ref Room r)
    {
        var tempP = ValidateInput.ValidateInteger("Ingrese el nuevo Precio: ");
        r.precio = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempP : r.precio;
    }

    private static void SetNewCancelable(ref Room r)
    {
        var tempA = ValidateInput.ValidateBoolean("Ingrese si es Cancelable (Si/No): ");
        r.cancelable = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempA : r.cancelable;
    }
}