using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Room
{
    public int id { get; set; }
    public int idHotel { get; set; }
    public int cantidadPlazas { get; set; }
    public int precio { get; set; }
    public int usuario { get; set; }
    public string categoria { get; set; }
    public bool cancelable { get; set; }

    public Room()
    {
    }

    public Room(int id, int idHotel, int quantitySpaces, int price, int user, string category,
        bool cancelable)
    {
        this.id = id;
        this.idHotel = idHotel;
        cantidadPlazas = quantitySpaces;
        precio = price;
        usuario = user;
        categoria = category;
        this.cancelable = cancelable;
    }

    public NameValueCollection HabitacionMap(Room h)
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

    public string ToReport()
    {
        return
            "     Código: " + id + "\n" +
            "     Cantidad Plazas: " + cantidadPlazas + "\n" +
            "     Categoria: " + categoria + "\n" +
            "     Precio: " + precio + "\n" +
            "     Cancelable: " + (cancelable ? "Sí" : "No");
    }
}