using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Reservation
{
    public int Id { get; set; }
    public int User { get; set; }
    public int QuantityGuests { get; set; }
    public int IdCustomer { get; set; }
    public int IdRoom { get; set; }
    public string DateEntry { get; set; }
    public string DateEgress { get; set; }

    public Reservation()
    {
    }

    public Reservation(int id, int user, int quantityGuests, int idCustomer, int idRoom,
        string dateEntry, string dateEgress)
    {
        Id = id;
        User = user;
        QuantityGuests = quantityGuests;
        IdCustomer = idCustomer;
        IdRoom = idRoom;
        DateEntry = dateEntry;
        DateEgress = dateEgress;
    }

    public NameValueCollection ReservaMap(Reservation r)
    {
        var n = new NameValueCollection
        {
            { "id", r.Id.ToString() },
            { "idHabitacion", r.IdRoom.ToString() },
            { "idCliente", r.IdCustomer.ToString() },
            { "cantidadHuespedes", r.QuantityGuests.ToString() },
            { "fechaIngreso", r.DateEntry },
            { "fechaEgreso", r.DateEgress },
            { "usuario", r.User.ToString() }
        };
        return n;
    }

    public string ToReport()
    {
        return "     Código: " + Id + "\n" +
               "     Habitacion: " + IdRoom + "\n" +
               "     Cantidad de Huespedes: " + QuantityGuests + "\n" +
               "     Fecha Ingreso: " + utils.Utils.DateTimeFormatter(DateEntry) + "\n" +
               "     Fecha Egreso: " + utils.Utils.DateTimeFormatter(DateEgress);
    }
}