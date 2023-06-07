using Hotel.main.abstraction;
using Hotel.main.entity;
using Hotel.main.services;

namespace Hotel.main.dao;

public class D_Habitacion : A_JsonConvert<Habitacion>, D_Factory<Habitacion>
{
    public List<Habitacion> Load()
    {
        var jsonClient = WebHelper.Get("Hotel/Habitaciones");
        return StringToJsonArray(jsonClient);
    }

    public List<Habitacion> Load(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Habitaciones/" + id);
        return StringToJsonArray(jsonClient);
    }

    public Habitacion Select(string id)
    {
        var jsonClient = WebHelper.Get("Hotel/Habitaciones/" + id);
        return StringToJsonObject(jsonClient);
    }

    public ResultadoTransaccion Insert(Habitacion c)
    {
        var obj = new S_Habitacion().HabitacionMap(c);
        var json = WebHelper.Post("Hotel/Habitaciones", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultadoTransaccion Update(Habitacion c)
    {
        var obj = new S_Habitacion().HabitacionMap(c);
        var json = WebHelper.Put("Hotel/Habitaciones", obj);

        return StringToJsonObjectTransaccion(json);
    }

    public ResultadoTransaccion Delete(Habitacion c)
    {
        var obj = new S_Habitacion().HabitacionMap(c);
        var json = WebHelper.Delete("Hotel/Habitaciones", obj);

        return StringToJsonObjectTransaccion(json);
    }
}