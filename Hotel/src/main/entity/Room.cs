using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Room
{
    public int Id { get; set; }
    public int IdHotel { get; set; }
    public int QuantitySpaces { get; set; }
    public int Price { get; set; }
    public int User { get; set; }
    public string Category { get; set; }
    public bool Cancelable { get; set; }

    public Room()
    {
    }

    public Room(int id, int idHotel, int quantitySpaces, int price, int user, string category,
        bool cancelable)
    {
        Id = id;
        IdHotel = idHotel;
        QuantitySpaces = quantitySpaces;
        Price = price;
        User = user;
        Category = category;
        Cancelable = cancelable;
    }

    public NameValueCollection HabitacionMap(Room h)
    {
        var n = new NameValueCollection
        {
            { "id", h.Id.ToString() },
            { "idHotel", h.IdHotel.ToString() },
            { "cantidadPlazas", h.QuantitySpaces.ToString() },
            { "categoria", h.Category },
            { "precio", h.Price.ToString() },
            { "cancelable", h.Cancelable.ToString() },
            { "usuario", h.User.ToString() }
        };
        return n;
    }

    public string ToReport()
    {
        return
            "     Código: " + IdHotel + "\n" +
            "     Cantidad Plazas: " + QuantitySpaces + "\n" +
            "     Categoria: " + Category + "\n" +
            "     Precio: " + Price + "\n" +
            "     Cancelable: " + (Cancelable ? "Sí" : "No");
    }
}