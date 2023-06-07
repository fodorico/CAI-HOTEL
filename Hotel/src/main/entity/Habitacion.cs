namespace Hotel.main.entity;

public class Habitacion
{
    public int id { get; set; }
    public int idHotel { get; set; }
    public int cantidadPlazas { get; set; }
    public int precio { get; set; }
    public int usuario { get; set; }
    public string categoria { get; set; }
    public bool cancelable { get; set; }

    public Habitacion(int id, int idHotel, int cantidadPlazas, int precio, int usuario, string categoria,
        bool cancelable)
    {
        this.id = id;
        this.idHotel = idHotel;
        this.cantidadPlazas = cantidadPlazas;
        this.precio = precio;
        this.usuario = usuario;
        this.categoria = categoria;
        this.cancelable = cancelable;
    }
}