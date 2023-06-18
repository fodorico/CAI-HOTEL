using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Customer : A_Person
{
    public int id { get; set; }

    public Customer()
    {
    }
    public Customer(string user)
    {
        usuario = user;
    }

    public Customer(int id, int doc, string name, string lastName, string address, string email,
        string phone, string user, DateTime dateBirth, DateTime entryDate, bool active)
    {
        this.id = id;
        dni = doc;
        nombre = name;
        apellido = lastName;
        direccion = address;
        this.email = email;
        telefono = phone;
        usuario = user;
        fechaNacimiento = dateBirth;
        fechaAlta = entryDate;
        activo = active;
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