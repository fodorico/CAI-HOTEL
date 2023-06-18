using Hotel.main.dao;
using Hotel.main.entity;

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
}