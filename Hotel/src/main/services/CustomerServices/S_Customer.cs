using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services.CustomerServices;

public class S_Customer
{
    public Customer GetCustomerData(int id)
    {
        return new D_Customer().Select(id.ToString());
    }

    public List<Customer> GetAllCustomer()
    {
        var lc = new D_Customer().Load();
        return lc.OrderByDescending(o => o.id).ToList();
    }

    public Customer SelectCustomer()
    {
        var result = new Customer();
        while (true)
        {
            var i = ValidateInput.ValidateInteger("Ingrese el numero de Legajo del Usuario existente: ");
            result = new S_Customer().GetCustomerData(i);
            if (!string.IsNullOrEmpty(result.usuario))
            {
                break;
            }
            Console.WriteLine("Ingrese un Legajo existente");
        }

        return result;
    }
}