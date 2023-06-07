using System.Collections.Specialized;
using Hotel.main.dao;

namespace Hotel.main.services;

public class S_Hotel
{
    public List<entity.Hotel> GetHotelesData(string id)
    {
        return new D_Hotel().Load(id);
    }

    public NameValueCollection HotelMap(entity.Hotel h)
    {
        var n = new NameValueCollection
        {
            { "id", h.id.ToString() },
            { "Estrellas", h.estrellas.ToString() },
            { "Usuario", h.usuario.ToString() },
            { "Amenities", h.amenities.ToString() },
            { "Direccion", h.direccion },
            { "Nombre", h.nombre }
        };
        return n;
    }
}