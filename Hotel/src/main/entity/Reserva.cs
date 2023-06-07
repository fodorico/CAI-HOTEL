namespace Hotel.main.entity;

public class Reserva
{
    public int id { get; set; }
    public int usuario { get; set; }
    public int cantidadHuespedes { get; set; }
    public int idCliente { get; set; }
    public int idHabitacion { get; set; }
    public string fechaIngreso { get; set; }
    public string fechaEgreso { get; set; }

    public Reserva(int id, int usuario, int cantidadHuespedes, int idCliente, int idHabitacion,
        string fechaIngreso, string fechaEgreso)
    {
        this.id = id;
        this.usuario = usuario;
        this.cantidadHuespedes = cantidadHuespedes;
        this.idCliente = idCliente;
        this.idHabitacion = idHabitacion;
        this.fechaIngreso = fechaIngreso;
        this.fechaEgreso = fechaEgreso;
    }
}