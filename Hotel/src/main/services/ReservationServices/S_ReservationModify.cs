using System.Globalization;
using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services.ReservationServices;

public class S_ReservationModify
{
    public void ModifyReservation(List<Reservation> r)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            opt = SwitchAndValidate(r);
        }
    }

    private bool SwitchAndValidate(List<Reservation> r)
    {
        Reservation res;
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

        return SwitchMenuReservation(ShowMenuReservation(), res);
    }

    private int ShowMenuReservation()
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

    private bool SwitchMenuReservation(int i, Reservation r)
    {
        switch (i)
        {
            case 1:
                SetNewQuantityGuests(r);
                break;
            case 2:
                SetNewDataEntry(ref r);
                SetNewDateEgress(ref r);
                break;
            case 3:
                SetNewDateEgress(ref r);
                break;
            default:
                return false;
        }

        new D_Reservation().Update(r);
        return false;
    }

    private static void SetNewQuantityGuests(Reservation r)
    {
        var tempCH = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Huespedes: ");
        r.cantidadHuespedes = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
            ? tempCH
            : r.cantidadHuespedes;
    }

    private static void SetNewDataEntry(ref Reservation r)
    {
        var tempFi = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Ingreso (DD-MM-YYYY): ",
            "inferior a la Fecha de Hoy", "more", DateTime.Now);
        r.fechaIngreso = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
            ? tempFi.ToString("d", CultureInfo.CurrentCulture)
            : r.fechaIngreso;
    }

    private static void SetNewDateEgress(ref Reservation r)
    {
        var tempFe = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Egreso (DD-MM-YYYY): ",
            "inferior a la Fecha de Ingreso", "more", DateTime.Now);
        r.fechaEgreso = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
            ? tempFe.ToString("d", CultureInfo.CurrentCulture)
            : r.fechaEgreso;
    }
}