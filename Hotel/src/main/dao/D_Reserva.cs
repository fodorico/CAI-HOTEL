using Hotel.main.abstraction;
using Hotel.main.entity;
using Hotel.main.services;

namespace Hotel.main.dao;

public class D_Reserva : A_JsonConvert<Reserva>, D_Factory<Reserva>
{
    public List<Reserva> Load()
    {
        var jsonClient = WebHelper.Get("Hotel/Reserva");
        return StringToJsonArray(jsonClient);
    }

    public List<Reserva> Load(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Reserva/" + id);
        return StringToJsonArray(jsonClient);
    }

    public Reserva Select(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Reserva/" + id);
        return StringToJsonObject(jsonClient);
    }

    public ResultadoTransaccion Insert(Reserva c)
    {
        var obj = new S_Reserva().ReservaMap(c);
        var json = WebHelper.Post("Hotel/Reserva", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultadoTransaccion Update(Reserva c)
    {
        var obj = new S_Reserva().ReservaMap(c);
        var json = WebHelper.Put("Hotel/Reserva", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultadoTransaccion Delete(Reserva c)
    {
        var obj = new S_Reserva().ReservaMap(c);
        var json = WebHelper.Delete("Hotel/Reserva", obj);

        return StringToJsonObjectTransaccion(json);
    }
}