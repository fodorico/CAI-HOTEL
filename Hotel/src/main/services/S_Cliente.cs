using System.Collections.Specialized;
using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services;

public class S_Cliente
{
    public Cliente GetClientData(int id)
    {
        return new D_Cliente().Select(id.ToString());
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
}