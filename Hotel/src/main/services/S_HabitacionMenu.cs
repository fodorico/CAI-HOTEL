using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services;

public class S_HabitacionMenu
{
    public void HabitacionMenu(Habitacion h)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            ShowDataHabitacion(h);
            opt = SwitchMenuHabitacion(ShowMenuHabitacion(), h);
        }
    }

    public void HabitacionMenu(List<Habitacion> h)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            foreach (var habitacion in h)
            {
                ShowDataHabitacion(habitacion);
            }

            var cod = ValidateInput.ValidateInteger("Por favor escriba el Código del Hotel que desea modificar: ", 0,
                999, true);
            opt = SwitchMenuHabitacion(ShowMenuHabitacion(), h.FirstOrDefault(t => t.id == cod));
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
        Console.WriteLine("     Código: " + h.idHotel);
        Console.WriteLine("     Cantidad Plazas: " + h.cantidadPlazas);
        Console.WriteLine("     Categoria: " + h.categoria);
        Console.WriteLine("     Precio: " + h.precio);
        Console.WriteLine("     Cancelable: " + (h.cancelable ? "Sí" : "No"));
        Console.WriteLine("══════════════════════════════════════════════════════");
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