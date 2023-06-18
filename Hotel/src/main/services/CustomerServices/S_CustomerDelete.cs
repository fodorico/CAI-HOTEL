using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services.CustomerServices;

public class S_CustomerDelete
{
    // TODO: Falta el menu de la eliminacion
    public ResultTransaction DeleteCustomerData(Customer c)
    {
        return new D_Customer().Delete(c);
    }
    
}