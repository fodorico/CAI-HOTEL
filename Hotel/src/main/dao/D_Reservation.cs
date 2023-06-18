using Hotel.main.abstraction;
using Hotel.main.entity;

namespace Hotel.main.dao;

public class D_Reservation : A_JsonConvert<Reservation>, D_Factory<Reservation>
{
    public List<Reservation> Load()
    {
        var jsonClient = WebHelper.Get("Hotel/Reservas");
        return StringToJsonArray(jsonClient);
    }

    public List<Reservation> Load(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Reservas/" + id);
        return StringToJsonArray(jsonClient);
    }

    public Reservation Select(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Reservas/" + id);
        return StringToJsonObject(jsonClient);
    }

    public ResultTransaction Insert(Reservation r)
    {
        var obj = new Reservation().ReservaMap(r);
        var json = WebHelper.Post("Hotel/Reservas", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultTransaction Update(Reservation r)
    {
        var obj = new Reservation().ReservaMap(r);
        var json = WebHelper.Put("Hotel/Reservas", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultTransaction Delete(Reservation r)
    {
        var obj = new Reservation().ReservaMap(r);
        var json = WebHelper.Delete("Hotel/Reservas", obj);

        return StringToJsonObjectTransaccion(json);
    }
}