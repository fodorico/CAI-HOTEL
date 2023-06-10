using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Cliente : A_Person
{
    public int id { get; set; }

    public Cliente()
    {
    }

    public Cliente(int id, int dni, string nombre, string apellido, string direccion, string email,
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

    public NameValueCollection ClienteMap(Cliente c)
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

    public string toReport()
    {
        return "     DNI: " + dni + "\t\tNombre Completo: " + nombre + " " + apellido + "\n" +
               "     Direccion: " + direccion + "\t\tTelefono: " + telefono + "\n" +
               "     Legajo: " + usuario + "\t\tFecha de Nacimiento: " + fechaNacimiento + "\n" +
               "     Email: " + email;
    }
}