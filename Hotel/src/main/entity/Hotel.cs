using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Hotel
{
    public int Id { get; set; }
    public int Stars { get; set; }
    public int User { get; set; }
    public bool Amenities { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }

    public Hotel()
    {
    }

    public Hotel(int id, int stars, int user, bool amenities, string address, string name)
    {
        Id = id;
        Stars = stars;
        User = user;
        Amenities = amenities;
        Address = address;
        Name = name;
    }

    public NameValueCollection HotelMap(Hotel h)
    {
        var n = new NameValueCollection
        {
            { "id", h.Id.ToString() },
            { "Estrellas", h.Stars.ToString() },
            { "Usuario", h.User.ToString() },
            { "Amenities", h.Amenities.ToString() },
            { "Direccion", h.Address },
            { "Nombre", h.Name }
        };
        return n;
    }

    public string ToReport()
    {
        return "      Código: " + Id + "\n" +
               "     Nombre: " + Name + "\n" +
               "     Estrellas: " + Stars + "\n" +
               "     Direccion: " + Address + "\n" +
               "     Comodidades: " + (Amenities ? "Sí" : "No");
    }
}