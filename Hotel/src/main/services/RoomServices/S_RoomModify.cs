using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

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

        return SwitchMenuHabitacion(ShowMenuHabitacion(), hab);
    }

    private int ShowMenuHabitacion()
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

    private bool SwitchMenuHabitacion(int i, Room r)
    {
        switch (i)
        {
            case 1:
                var tempCP = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Plazas: ");
                r.cantidadPlazas = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempCP
                    : r.cantidadPlazas;
                break;
            case 2:
                var tempC = ValidateInput.ValidateString("Ingrese la nueva Categoria: ", "IsLetter");
                r.categoria = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempC : r.categoria;
                break;
            case 3:
                var tempP = ValidateInput.ValidateInteger("Ingrese el nuevo Precio: ");
                r.precio = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempP : r.precio;
                break;
            case 4:
                var tempA = ValidateInput.ValidateBoolean("Ingrese si es Cancelable (Si/No): ");
                r.cancelable = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempA : r.cancelable;
                break;
            default:
                return false;
        }

        new D_Room().Update(r);
        return true;
    }
}