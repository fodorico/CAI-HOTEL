using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.utils;

namespace Hotel.main.services.CustomerServices;

public class S_Customer
{
    public Customer SelectCustomer(string text)
    {
        var result = new List<Customer>();
        while (true)
        {
            var i = ValidateInput.ValidateInteger(text);
            result = new S_Customer().GetCustomerData(i);
            if (result.Any())
            {
                break;
            }

            Console.WriteLine("El Legajo no pertenece a un Usuario existente");
        }

        return result[0];
    }

    private List<Customer> GetCustomerData(int id)
    {
        var result = new D_Customer().Load(id.ToString());
        return result;
    }

    public List<Customer> GetAllCustomer()
    {
        var lc = new D_Customer().Load();
        return lc.OrderByDescending(o => o.id).ToList();
    }
}