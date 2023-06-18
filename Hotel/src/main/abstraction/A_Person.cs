public abstract class A_Person
{
    public int dni { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string direccion { get; set; }
    public string email { get; set; }
    public string telefono { get; set; }
    public string usuario { get; set; }
    public DateTime fechaNacimiento { get; set; }
    public DateTime fechaAlta { get; set; }
    public bool activo { get; set; }

    public string GetFullName()
    {
        return $"{nombre} {apellido}";
    }
}