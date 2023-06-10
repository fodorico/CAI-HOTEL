using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Reserva
{
    public int id { get; set; }
    public int usuario { get; set; }
    public int cantidadHuespedes { get; set; }
    public int idCliente { get; set; }
    public int idHabitacion { get; set; }
    public string fechaIngreso { get; set; }
    public string fechaEgreso { get; set; }

    public Reserva()
    {
    }

    public Reserva(int id, int usuario, int cantidadHuespedes, int idCliente, int idHabitacion,
        string fechaIngreso, string fechaEgreso)
    {
        this.id = id;
        this.usuario = usuario;
        this.cantidadHuespedes = cantidadHuespedes;
        this.idCliente = idCliente;
        this.idHabitacion = idHabitacion;
        this.fechaIngreso = fechaIngreso;
        this.fechaEgreso = fechaEgreso;
    }

    public NameValueCollection ReservaMap(Reserva r)
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

    public string toReport()
    {
        return "     Código: " + id + "\n" +
               "     Habitacion: " + idHabitacion + "\n" +
               "     Cantidad de Huespedes: " + cantidadHuespedes + "\n" +
               "     Fecha Ingreso: " + fechaIngreso + "\n" +
               "     Fecha Egreso: " + fechaEgreso;
    }
}