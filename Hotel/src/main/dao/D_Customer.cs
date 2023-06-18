using Hotel.main.abstraction;
using Hotel.main.entity;

namespace Hotel.main.dao;

public class D_Customer : A_JsonConvert<Customer>, D_Factory<Customer>
{
    public List<Customer> Load()
    {
        var jsonClient = WebHelper.Get("cliente");
        return StringToJsonArray(jsonClient);
    }

    public List<Customer> Load(string id)
    {
        var jsonClient = WebHelper.Get("cliente/" + id);
        return StringToJsonArray(jsonClient);
    }

    public Customer Select(string id)
    {
        var jsonClient = WebHelper.Get("cliente/" + id);
        return StringToJsonArray(jsonClient)[0];
    }

    public ResultTransaction Insert(Customer c)
    {
        var obj = new Customer().CustomerMap(c);
        var json = WebHelper.Post("cliente", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultTransaction Update(Customer c)
    {
        var obj = new Customer().CustomerMap(c);
        var json = WebHelper.Put("cliente", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultTransaction Delete(Customer c)
    {
        var obj = new Customer().CustomerMap(c);
        var json = WebHelper.Delete("cliente", obj);

        return StringToJsonObjectTransaccion(json);
    }
}