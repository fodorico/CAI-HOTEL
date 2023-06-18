using System.Globalization;
using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services.ReservationServices;

public class S_ReservationModify
{
    public void ModifyReserva(List<Reservation> r)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            opt = ValidateInput.ValidateBoolean("Desea modificar un dato de una Reserva? (Si / No): ")
                ? SwitchAndValidate(r)
                : false;
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
            res = r.FirstOrDefault(t => t.Id == cod);
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

    private bool SwitchMenuReserva(int i, Reservation r)
    {
        switch (i)
        {
            case 1:
                var tempCH = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Huespedes: ");
                r.QuantityGuests = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempCH
                    : r.QuantityGuests;
                break;
            case 2:
                var tempFi = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Ingreso (DD-MM-YYYY): ",
                    "inferior a la Fecha de Hoy", "more", DateTime.Now);
                r.DateEntry = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempFi.ToString("d", CultureInfo.CurrentCulture)
                    : r.DateEntry;
                break;
            case 3:
                var tempFe = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Egreso (DD-MM-YYYY): ",
                    "inferior a la Fecha de Ingreso", "more", DateTime.Now);
                r.DateEgress = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempFe.ToString("d", CultureInfo.CurrentCulture)
                    : r.DateEgress;
                break;
            default:
                return false;
        }

        new D_Reservation().Update(r);
        return true;
    }
}