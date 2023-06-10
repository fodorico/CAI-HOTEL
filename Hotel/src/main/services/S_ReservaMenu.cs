using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services;

public class S_ReservaMenu
{
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

            Comment.StopToThink();
            opt = ValidateInput.ValidateBoolean("Desea modificar un dato de una Reserva? (Si / No): ")
                ? SwitchAndValidate(r)
                : false;
        }
    }

    private void ShowData()
    {
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Detalle Reservas                  ");
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private static void ShowDataReserva(Reserva r)
    {
        Console.WriteLine(r.toReport());
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private bool SwitchAndValidate(List<Reserva> r)
    {
        Reserva res;
        while (true)
        {
            var cod = ValidateInput.ValidateInteger("Por favor escriba el Código de la Reserva que desea modificar: ",
                0,
                999, true);
            res = r.FirstOrDefault(t => t.id == cod);
            if (res != null)
            {
                break;
            }

            Console.WriteLine("Por favor coloque un código valido!");
        }

        return SwitchMenuReserva(ShowMenuReserva(), res);
    }

    private int ShowMenuReserva()
    {
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Menú Reservas                     ");
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