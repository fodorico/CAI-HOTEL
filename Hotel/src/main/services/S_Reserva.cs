using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services;

public class S_Reserva
{
    public List<Reserva> GetReservasData(string id)
    {
        return new D_Reserva().Load(id);
    }

    public Reserva SaveNewReserva(Cliente c)
    {
        Console.Clear();
        var nextId = GetAllReserva()[0].id + 1;
        var newReserva = new Reserva(
            nextId,
            int.Parse(c.usuario),
            ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Huespedes: "),
            c.id,
            new S_Habitacion().GetHabitacion(),
            ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Ingreso (DD-MM-YYYY): ").ToString(),
            ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Egreso (DD-MM-YYYY): ").ToString()
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Reserva().Insert(newReserva);
        }

        return newReserva;
    }

    private List<Reserva> GetAllReserva()
    {
        var lr = new D_Reserva().Load();
        return lr.OrderByDescending(o => o.id).ToList();
    }
}