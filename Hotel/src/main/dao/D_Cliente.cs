using Hotel.main.abstraction;
using Hotel.main.entity;
using Hotel.main.services;

namespace Hotel.main.dao;

public class D_Cliente : A_JsonConvert<Cliente>, D_Factory<Cliente>
{
    public List<Cliente> Load()
    {
        var jsonClient = WebHelper.Get("cliente");
        return StringToJsonArray(jsonClient);
    }

    public List<Cliente> Load(string id)
    {
        var jsonClient = WebHelper.Get("cliente/" + id);
        return StringToJsonArray(jsonClient);
    }

    public Cliente Select(string id)
    {
        var jsonClient = WebHelper.Get("cliente/" + id);
        // TODO: NO TRAE LOS USUARIOS ACTUALIZADOS
        return StringToJsonArray(jsonClient)[0];
    }

    public ResultadoTransaccion Insert(Cliente c)
    {
        var obj = new S_Cliente().ClienteMap(c);
        var json = WebHelper.Post("cliente", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultadoTransaccion Update(Cliente c)
    {
        var obj = new S_Cliente().ClienteMap(c);
        var json = WebHelper.Put("cliente", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultadoTransaccion Delete(Cliente c)
    {
        var obj = new S_Cliente().ClienteMap(c);
        var json = WebHelper.Delete("cliente", obj);

        return StringToJsonObjectTransaccion(json);
    }
}