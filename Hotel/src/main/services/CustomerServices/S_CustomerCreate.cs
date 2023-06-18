using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services.CustomerServices;

public class S_CustomerCreate
{

    public Customer NewCustomer()
    {
        Console.Clear();
        var nextId = new S_Customer().GetAllCustomer()[0].Id + 1;
        var newCustomer = new entity.Customer(
            nextId,
            ValidateInput.ValidateInteger("Ingrese el nuevo DNI: ", -1, 99999999, true),
            ValidateInput.ValidateString("Ingrese el nuevo Nombre: ", "IsLetter"),
            ValidateInput.ValidateString("Ingrese el nuevo Apellido: ", "IsLetter"),
            ValidateInput.ValidateString("Ingrese la nueva Dirección: ", "All"),
            ValidateInput.ValidateString("Ingrese el nuevo Email: ", "All"),
            ValidateInput.ValidateString("Ingrese el nuevo Telefono (Sin espcios/guiones): ", "IsDigit"),
            ValidateInput.ValidateString("Ingrese el nuevo Legajo: ", "IsDigit"),
            ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Nacimiento (DD-MM-YYYY): ",
                "superior a la Fecha de Hoy", "less", DateTime.Now),
            DateTime.Today,
            true
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Customer().Insert(newCustomer);
        }

        return newCustomer;
    }
}