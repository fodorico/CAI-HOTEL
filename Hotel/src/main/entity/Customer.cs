using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Customer : A_Person
{
    public int id { get; set; }

    public Customer()
    {
    }

    public Customer(int id, int dni, string nombre, string apellido, string direccion, string email,
        string telefono, string usuario, DateTime fechaNacimiento, DateTime fechaAlta, bool activo)
    {
        this.id = id;
        this.dni = dni;
        this.nombre = nombre;
        this.apellido = apellido;
        this.direccion = direccion;
        this.email = email;
        this.telefono = telefono;
        this.usuario = usuario;
        this.fechaNacimiento = fechaNacimiento;
        this.fechaAlta = fechaAlta;
        this.activo = activo;
    }

    public NameValueCollection CustomerMap(Customer c)
    {
        var n = new NameValueCollection
        {
            { "id", c.id.ToString() },
            { "Nombre", c.nombre },
            { "Apellido", c.apellido },
            { "Direccion", c.direccion },
            { "Telefono", c.telefono },
            { "Email", c.email },
            { "DNI", c.dni.ToString() },
            { "Activo", c.activo.ToString() },
            { "FechaNacimiento", c.fechaNacimiento.ToString("yyyy-MM-dd") },
            { "Usuario", c.usuario }
        };
        return n;
    }

    public string ToReport()
    {
        return "     DNI: " + dni + "\t\tNombre Completo: " + GetFullName() + "\n" +
               "     Telefono: " + telefono + "\tDireccion: " + direccion + "\n" +
               "     Legajo: " + usuario + "\t\tFecha de Nacimiento: " +
               utils.Utils.DateTimeFormatter(fechaNacimiento) + "\n" +
               "     Email: " + email;
    }
}