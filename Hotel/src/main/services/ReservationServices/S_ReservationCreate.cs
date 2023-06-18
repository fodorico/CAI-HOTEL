using System.Globalization;
using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.services.RoomServices;
using Utils;

namespace Hotel.main.services.ReservationServices;

public class S_ReservationCreate
{
    public Reservation NewReservation(Customer c)
    {
        Console.Clear();
        var nextId = new S_Reservation().GetAllReservation()[0].Id + 1;
        var tempFi = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Ingreso (DD-MM-YYYY): ",
            "inferior a la Fecha de Hoy", "more", DateTime.Now);
        var tempFe = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Egreso (DD-MM-YYYY): ",
            "inferior a la Fecha de Ingreso", "more", tempFi).ToString("d", CultureInfo.CurrentCulture);
        var newReservation = new Reservation(
            nextId,
            int.Parse(c.User),
            ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Huespedes: "),
            c.Id,
            new S_Room().SelectIdRoom(),
            tempFi.ToString("d", CultureInfo.CurrentCulture),
            tempFe
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Reservation().Insert(newReservation);
        }

        return newReservation;
    }
}