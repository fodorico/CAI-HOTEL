using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Reservation
{
    public int id { get; set; }
    public int usuario { get; set; }
    public int cantidadHuespedes { get; set; }
    public int idCliente { get; set; }
    public int idHabitacion { get; set; }
    public string fechaIngreso { get; set; }
    public string fechaEgreso { get; set; }

    public Reservation()
    {
    }

    public Reservation(int id, int user, int quantityGuests, int idCustomer, int idRoom,
        string dateEntry, string dateEgress)
    {
        this.id = id;
        usuario = user;
        cantidadHuespedes = quantityGuests;
        idCliente = idCustomer;
        idHabitacion = idRoom;
        fechaIngreso = dateEntry;
        fechaEgreso = dateEgress;
    }

    public NameValueCollection ReservaMap(Reservation r)
    {
        var n = new NameValueCollection
        {
            { "id", r.id.ToString() },
            { "idHabitacion", r.idHabitacion.ToString() },
            { "idCliente", r.idCliente.ToString() },
            { "cantidadHuespedes", r.cantidadHuespedes.ToString() },
            { "fechaIngreso", r.fechaIngreso },
            { "fechaEgreso", r.fechaEgreso },
            { "usuario", r.usuario.ToString() }
        };
        return n;
    }

    public string ToReport()
    {
        return "     Código: " + id + "\n" +
               "     Habitacion: " + idHabitacion + "\n" +
               "     Cantidad de Huespedes: " + cantidadHuespedes + "\n" +
               "     Fecha Ingreso: " + utils.Utils.DateTimeFormatter(fechaIngreso) + "\n" +
               "     Fecha Egreso: " + utils.Utils.DateTimeFormatter(fechaEgreso);
    }
}