using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Hotel
{
    public int id { get; set; }
    public int estrellas { get; set; }
    public int usuario { get; set; }
    public bool amenities { get; set; }
    public string direccion { get; set; }
    public string nombre { get; set; }

    public Hotel()
    {
    }

    public Hotel(int id, int stars, int user, bool amenities, string address, string name)
    {
        this.id = id;
        estrellas = stars;
        usuario = user;
        this.amenities = amenities;
        direccion = address;
        nombre = name;
    }

    public NameValueCollection HotelMap(Hotel h)
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

    public string ToReport()
    {
        return "      Código: " + id + "\n" +
               "     Nombre: " + nombre + "\n" +
               "     Estrellas: " + estrellas + "\n" +
               "     Direccion: " + direccion + "\n" +
               "     Comodidades: " + (amenities ? "Sí" : "No");
    }
}