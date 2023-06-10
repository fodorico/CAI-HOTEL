using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services;

public class S_Habitacion
{
    public List<Habitacion> GetHabitacionData(string id)
    {
        return new D_Habitacion().Load(id);
    }

    public int GetHabitacion()
    {
        var lh = new S_Hotel().GetHoteles();
        // Loop
        // Elegir el hotel
        // Verificar si tiene la cantidad necesiario de espacio para alguna habitacion
        // !Loop
        return 0;
    }
}