using Hotel.main.abstraction;
using Hotel.main.entity;

namespace Hotel.main.dao;

public class D_Room : A_JsonConvert<Room>, D_Factory<Room>
{
    public List<Room> Load()
    {
        var jsonClient = WebHelper.Get("Hotel/Habitaciones");
        return StringToJsonArray(jsonClient);
    }

    public List<Room> Load(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Habitaciones/" + id);
        return StringToJsonArray(jsonClient);
    }

    public Room Select(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Habitaciones/" + id);
        return StringToJsonObject(jsonClient);
    }

    public ResultTransaction Insert(Room r)
    {
        var obj = new Room().HabitacionMap(r);
        var json = WebHelper.Post("Hotel/Habitaciones", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultTransaction Update(Room r)
    {
        var obj = new Room().HabitacionMap(r);
        var json = WebHelper.Put("Hotel/Habitaciones", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultTransaction Delete(Room r)
    {
        var obj = new Room().HabitacionMap(r);
        var json = WebHelper.Delete("Hotel/Habitaciones", obj);

        return StringToJsonObjectTransaccion(json);
    }
}