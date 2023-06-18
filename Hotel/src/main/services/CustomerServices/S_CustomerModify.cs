using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services.CustomerServices;

public class S_CustomerModify
{
    public void ModifyCustomer(entity.Customer c)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            opt = ValidateInput.ValidateBoolean("Desea modificar un dato del Usuario? (Si / No): ")
                ? SwitchMenuModifyCustomer(ShowMenuModificarCliente(), c)
                : false;
        }
    }

    private int ShowMenuModificarCliente()
    {
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Menú Cliente                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("¿Qué datos le gustaría modificar?");
        Console.WriteLine("     1. DNI\t\t2. Nombre");
        Console.WriteLine("     3. Apellido\t4. Dirección");
        Console.WriteLine("     5. Email\t\t6. Telefono");
        Console.WriteLine("     7. Legajo\t\t8. Fecha de Nacimiento");
        Console.WriteLine("     0. Salir");
        Console.WriteLine("══════════════════════════════════════════════════════");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 9, true);
    }

    private bool SwitchMenuModifyCustomer(int i, Customer c)
    {
        switch (i)
        {
            case 1:
                var tempDn = ValidateInput.ValidateInteger("Ingrese el nuevo DNI: ", -1, 99999999, true);
                c.Doc = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempDn : c.Doc;
                break;
            case 2:
                var tempN = ValidateInput.ValidateString("Ingrese el nuevo Nombre: ", "IsLetter");
                c.Name = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempN : c.Name;
                break;
            case 3:
                var tempA = ValidateInput.ValidateString("Ingrese el nuevo Apellido: ", "IsLetter");
                c.LastName = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempA : c.LastName;
                break;
            case 4:
                var tempDi = ValidateInput.ValidateString("Ingrese la nueva Dirección: ");
                c.Address = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempDi : c.Address;
                break;
            case 5:
                var tempE = ValidateInput.ValidateString("Ingrese el nuevo Email: ");
                c.Email = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempE : c.Email;
                break;
            case 6:
                var tempT =
                    ValidateInput.ValidateString("Ingrese el nuevo Telefono (Sin espcios/guiones): ", "IsDigit");
                c.Phone = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempT : c.Phone;
                break;
            case 7:
                var tempL = ValidateInput.ValidateString("Ingrese el nuevo Legajo: ", "IsDigit");
                c.User = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempL : c.User;
                break;
            case 8:
                var tempFn = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Nacimiento (DD-MM-YYYY): ",
                    "superior a la Fecha de Hoy", "less", DateTime.Now);
                c.DateBirth = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempFn
                    : c.DateBirth;
                break;
            default:
                return false;
        }

        new D_Customer().Update(c);
        return true;
    }
}