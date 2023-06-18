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
            opt = SwitchMenuModifyCustomer(ShowMenuModificarCliente(), c);
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
                c.dni = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempDn : c.dni;
                break;
            case 2:
                var tempN = ValidateInput.ValidateString("Ingrese el nuevo Nombre: ", "IsLetter");
                c.nombre = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempN : c.nombre;
                break;
            case 3:
                var tempA = ValidateInput.ValidateString("Ingrese el nuevo Apellido: ", "IsLetter");
                c.apellido = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempA : c.apellido;
                break;
            case 4:
                var tempDi = ValidateInput.ValidateString("Ingrese la nueva Dirección: ");
                c.direccion = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempDi : c.direccion;
                break;
            case 5:
                var tempE = ValidateInput.ValidateString("Ingrese el nuevo Email: ");
                c.email = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempE : c.email;
                break;
            case 6:
                var tempT =
                    ValidateInput.ValidateString("Ingrese el nuevo Telefono (Sin espcios/guiones): ", "IsDigit");
                c.telefono = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempT : c.telefono;
                break;
            case 7:
                var tempL = ValidateInput.ValidateString("Ingrese el nuevo Legajo: ", "IsDigit");
                c.usuario = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempL : c.usuario;
                break;
            case 8:
                var tempFn = ValidateInput.ValidateDateTime("Ingrese la nueva Fecha de Nacimiento (DD-MM-YYYY): ",
                    "superior a la Fecha de Hoy", "less", DateTime.Now);
                c.fechaNacimiento = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI"
                    ? tempFn
                    : c.fechaNacimiento;
                break;
            default:
                return false;
        }

        new D_Customer().Update(c);
        return true;
    }
}