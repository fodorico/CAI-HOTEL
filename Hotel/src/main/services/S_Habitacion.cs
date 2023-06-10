using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services;

public class S_Habitacion
{
    public List<Habitacion> GetHabitacionData(string id)
    {
        return new D_Habitacion().Load(id);
    }
}