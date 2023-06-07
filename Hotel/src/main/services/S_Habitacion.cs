using System.Collections.Specialized;
using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services;

public class S_Habitacion
{
    public List<Habitacion> GetHabitacionData(string id)
    {
        return new D_Habitacion().Load(id);
    }

    public NameValueCollection HabitacionMap(Habitacion h)
    {
        var n = new NameValueCollection
        {
            { "id", h.id.ToString() },
            { "idHotel", h.idHotel.ToString() },
            { "cantidadPlazas", h.cantidadPlazas.ToString() },
            { "categoria", h.categoria },
            { "precio", h.precio.ToString() },
            { "cancelable", h.cancelable.ToString() },
            { "usuario", h.usuario.ToString() }
        };
        return n;
    }
}