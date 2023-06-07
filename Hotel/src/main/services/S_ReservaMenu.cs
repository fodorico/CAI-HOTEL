using System.Collections.Specialized;
using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services;

public class S_ReservaMenu
{
    public void ReservaMenu(Reserva r)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            ShowDataReserva(r);
            opt = SwitchMenuReserva(ShowMenuReserva(), r);
        }
    }

    public void ReservaMenu(List<Reserva> r)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            foreach (var reserva in r)
            {
                ShowDataReserva(reserva);
            }

            var cod = ValidateInput.ValidateInteger("Por favor escriba el Código del Hotel que desea modificar: ", 0,
                999, true);
            opt = SwitchMenuReserva(ShowMenuReserva(), r.FirstOrDefault(t => t.id == cod));
        }
    }

    private void ShowData()
    {
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Detalle Reserva                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private static void ShowDataReserva(Reserva r)
    {
        Console.WriteLine("     Código: " + r.id);
        Console.WriteLine("     Habitacion: " + r.idHabitacion);
        Console.WriteLine("     Cantidad de Huespedes: " + r.cantidadHuespedes);
        Console.WriteLine("     Fecha Ingreso: " + r.fechaIngreso);
        Console.WriteLine("     Fecha Egreso: " + r.fechaEgreso);
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private int ShowMenuReserva()
    {
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Menú Reserva                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("¿Qué datos le gustaría modificar?");
        Console.WriteLine("     1. Cantidad de Huespedes");
        Console.WriteLine("     2. Fecha Ingreso");
        Console.WriteLine("     3. Fecha Egreso");
        Console.WriteLine("     0. Salir");
        Console.WriteLine("══════════════════════════════════════════════════════");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 4, true);
    }

    private bool SwitchMenuReserva(int i, Reserva r)
    {
        switch (i)
        {
            case 1:
                var tempCH = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Huespedes: ");
                r.cantidadHuespedes = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempCH
                    : r.cantidadHuespedes;
                break;
            case 2:
                var tempFI = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Ingreso (DD-MM-YYYY): ");
                r.fechaIngreso = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempFI.ToString()
                    : r.fechaIngreso;
                break;
            case 3:
                var tempFE = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Egreso (DD-MM-YYYY): ");
                r.fechaEgreso = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempFE.ToString()
                    : r.fechaEgreso;
                break;
            default:
                return false;
        }

        new D_Reserva().Update(r);
        return true;
    }
}