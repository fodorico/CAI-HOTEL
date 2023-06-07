using System.Collections.Specialized;

namespace Hotel.main.entity;

public class Cliente : A_Person
{
    public int id { get; set; }

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
}