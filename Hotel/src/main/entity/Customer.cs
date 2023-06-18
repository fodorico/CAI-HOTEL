using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Customer : A_Person
{
    public int Id { get; set; }

    public Customer()
    {
    }

    public Customer(int id, int doc, string name, string lastName, string address, string email,
        string phone, string user, DateTime dateBirth, DateTime entryDate, bool active)
    {
        Id = id;
        Doc = doc;
        Name = name;
        LastName = lastName;
        Address = address;
        Email = email;
        Phone = phone;
        User = user;
        DateBirth = dateBirth;
        EntryDate = entryDate;
        Active = active;
    }

    public NameValueCollection CustomerMap(Customer c)
    {
        var n = new NameValueCollection
        {
            { "id", c.Id.ToString() },
            { "Nombre", c.Name },
            { "Apellido", c.LastName },
            { "Direccion", c.Address },
            { "Telefono", c.Phone },
            { "Email", c.Email },
            { "DNI", c.Doc.ToString() },
            { "Activo", c.Active.ToString() },
            { "FechaNacimiento", c.DateBirth.ToString("yyyy-MM-dd") },
            { "Usuario", c.User }
        };
        return n;
    }

    public string ToReport()
    {
        return "     DNI: " + Doc + "\t\tNombre Completo: " + GetFullName() + "\n" +
               "     Telefono: " + Phone + "\tDireccion: " + Address + "\n" +
               "     Legajo: " + User + "\t\tFecha de Nacimiento: " +
               utils.Utils.DateTimeFormatter(DateBirth) + "\n" +
               "     Email: " + Email;
    }
}