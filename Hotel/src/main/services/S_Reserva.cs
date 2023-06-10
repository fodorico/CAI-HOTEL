using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services;

public class S_Reserva
{
    public List<Reserva> GetReservasData(string id)
    {
        return new D_Reserva().Load(id);
    }
}