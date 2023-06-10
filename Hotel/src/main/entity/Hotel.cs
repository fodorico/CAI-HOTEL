using System.Collections.Specialized;
using Hotel.main.services;

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

    public Hotel(int id, int estrellas, int usuario, bool amenities, string direccion, string nombre)
    {
        this.id = id;
        this.estrellas = estrellas;
        this.usuario = usuario;
        this.amenities = amenities;
        this.direccion = direccion;
        this.nombre = nombre;
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

    public string toReport()
    {
        return "      Código: " + id + "\n" +
               "     Nombre: " + nombre + "\n" +
               "     Estrellas: " + estrellas + "\n" +
               "     Direccion: " + direccion + "\n" +
               "     Comodidades: " + (amenities ? "Sí" : "No");
    }
}