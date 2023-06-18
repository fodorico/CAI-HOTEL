using Hotel.main.abstraction;
using Hotel.main.entity;

namespace Hotel.main.dao;

public class D_Hotel : A_JsonConvert<entity.Hotel>, D_Factory<entity.Hotel>
{
    public List<entity.Hotel> Load()
    {
        var jsonClient = WebHelper.Get("Hotel/Hoteles");
        return StringToJsonArray(jsonClient);
    }

    public List<entity.Hotel> Load(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Hoteles/" + id);
        return StringToJsonArray(jsonClient);
    }

    public entity.Hotel Select(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Hoteles/" + id);
        return StringToJsonObject(jsonClient);
    }

    public ResultTransaction Insert(entity.Hotel h)
    {
        var obj = new entity.Hotel().HotelMap(h);
        var json = WebHelper.Post("Hotel/Hoteles", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultTransaction Update(entity.Hotel h)
    {
        var obj = new entity.Hotel().HotelMap(h);
        var json = WebHelper.Put("Hotel/Hoteles", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultTransaction Delete(entity.Hotel h)
    {
        var obj = new entity.Hotel().HotelMap(h);
        var json = WebHelper.Delete("Hotel/Hoteles", obj);

        return StringToJsonObjectTransaccion(json);
    }
}