using Hotel.main.abstraction;
using Hotel.main.entity;
using Hotel.main.services;

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

    public ResultadoTransaccion Insert(entity.Hotel c)
    {
        var obj = new S_Hotel().HotelMap(c);
        var json = WebHelper.Post("Hotel/Hoteles", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultadoTransaccion Update(entity.Hotel c)
    {
        var obj = new S_Hotel().HotelMap(c);
        var json = WebHelper.Put("Hotel/Hoteles", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultadoTransaccion Delete(entity.Hotel c)
    {
        var obj = new S_Hotel().HotelMap(c);
        var json = WebHelper.Delete("Hotel/Hoteles", obj);

        return StringToJsonObjectTransaccion(json);
    }
}