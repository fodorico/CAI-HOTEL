using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.services.RoomServices;
using Hotel.main.utils;

namespace Hotel.main.services.ReservationServices;

public class S_ReservationCreate
{
    public Reservation NewReservation(Customer c)
    {
        Console.Clear();
        var nextId = new S_Reservation().GetAllReservation()[0].id + 1;
        var tempFi = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Ingreso (DD-MM-YYYY): ",
            "inferior a la Fecha de Hoy", "more", DateTime.Now);
        var tempFe = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Egreso (DD-MM-YYYY): ",
            "inferior a la Fecha de Ingreso", "more", tempFi).ToString("yyyy-MM-ddTHH:mm:ss");
        var tempQg = 0;
        do
        {
            tempQg = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Huespedes: ");
        } while (ValidateInput.Confirm("Es la cantidad de Huespedes correcta? (Si / No): ") != "SI");

        var room = new S_Room().SelectIdRoom();
        if (tempQg > room.cantidadPlazas)

        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════════════════════════");
            Console.WriteLine(
                "Seleccionó una Habitación con una capacidad menor a lo solicitado. Se anula la reserva.");
            Comment.StopToThink("Para continuar toque una tecla...." +
                                "\n══════════════════════════════════════════════════════");
            return new Reservation();
        }

        var newReservation = new Reservation(
            nextId,
            int.Parse(c.usuario),
            tempQg,
            c.id,
            room.id,
            tempFi.ToString("yyyy-MM-ddTHH:mm:ss"),
            tempFe
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Reservation().Insert(newReservation);
        }

        return newReservation;
    }
}