namespace Hotel.main.entity;

public class Hotel
{
    public int id { get; set; }
    public int estrellas { get; set; }
    public int usuario { get; set; }
    public bool amenities { get; set; }
    public string direccion { get; set; }
    public string nombre { get; set; }

    public Hotel(int id, int estrellas, int usuario, bool amenities, string direccion, string nombre)
    {
        this.id = id;
        this.estrellas = estrellas;
        this.usuario = usuario;
        this.amenities = amenities;
        this.direccion = direccion;
        this.nombre = nombre;
    }
}