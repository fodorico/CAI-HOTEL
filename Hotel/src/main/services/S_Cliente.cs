using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services;

public class S_Cliente
{
    public Cliente GetClientData(int id)
    {
        return new D_Cliente().Select(id.ToString());
    }

    public Cliente SaveNewCliente()
    {
        Console.Clear();
        var nextId = GetAllClient()[0].id + 1;
        var newClient = new Cliente(
            nextId,
            ValidateInput.ValidateInteger("Ingrese el nuevo DNI: ", -1, 99999999, true),
            ValidateInput.ValidateString("Ingrese el nuevo Nombre: ", "IsLetter"),
            ValidateInput.ValidateString("Ingrese el nuevo Apellido: ", "IsLetter"),
            ValidateInput.ValidateString("Ingrese la nueva Dirección: "),
            ValidateInput.ValidateString("Ingrese el nuevo Email: "),
            ValidateInput.ValidateString("Ingrese el nuevo Telefono (Sin espcios/guiones): ", "IsDigit"),
            ValidateInput.ValidateString("Ingrese el nuevo Legajo: ", "IsDigit"),
            ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Nacimiento (DD-MM-YYYY): "),
            DateTime.Today,
            true
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Cliente().Insert(newClient);
        }

        return newClient;
    }

    private List<Cliente> GetAllClient()
    {
        var lc = new D_Cliente().Load();
        return lc.OrderByDescending(o => o.id).ToList();
    }
}