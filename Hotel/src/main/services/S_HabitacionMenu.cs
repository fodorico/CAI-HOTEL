using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services;

public class S_HabitacionMenu
{
    private static List<Habitacion> _habitacions;

    public void HabitacionMenu(List<entity.Hotel> h, List<Reserva> r)
    {
        GetAllRooms(h, r);
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            foreach (var habitacion in _habitacions)
            {
                ShowDataHabitacion(habitacion);
            }

            opt = Comment.StopToThink();
            // opt = ValidateInput.ValidateBoolean("Desea modificar un dato de una Habitación? (Si / No): ")
            //     ? SwitchAndValidate(_habitacions)
            //     : false;
        }
    }

    private void GetAllRooms(List<entity.Hotel> hotels, List<Reserva> reservas)
    {
        List<int> habList = null;
        habList.AddRange(reservas.Select(r => r.idHabitacion));

        foreach (var ha in hotels.Select(h => new S_Habitacion().GetHabitacionData(h.id.ToString())).SelectMany(temp =>
                     from ha in temp let temp2 = habList.FirstOrDefault(t => t == ha.id) where temp2 != null select ha))
        {
            _habitacions.Add(ha);
        }
    }

    private void ShowData()
    {
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Detalle Habitacion                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private static void ShowDataHabitacion(Habitacion h)
    {
        Console.WriteLine(h.toReport());
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private bool SwitchAndValidate(List<Habitacion> h)
    {
        Habitacion hab;
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

    private bool SwitchMenuHabitacion(int i, Habitacion h)
    {
        switch (i)
        {
            case 1:
                var tempCP = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Plazas: ");
                h.cantidadPlazas = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempCP
                    : h.cantidadPlazas;
                break;
            case 2:
                var tempC = ValidateInput.ValidateString("Ingrese la nueva Categoria: ", "IsLetter");
                h.categoria = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempC : h.categoria;
                break;
            case 3:
                var tempP = ValidateInput.ValidateInteger("Ingrese el nuevo Precio: ");
                h.precio = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempP : h.precio;
                break;
            case 4:
                var tempA = ValidateInput.ValidateBoolean("Ingrese si es Cancelable (Si/No): ");
                h.cancelable = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempA : h.cancelable;
                break;
            default:
                return false;
        }

        new D_Habitacion().Update(h);
        return true;
    }
}