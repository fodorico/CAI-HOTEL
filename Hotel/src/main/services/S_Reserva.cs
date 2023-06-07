using System.Collections.Specialized;
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
}