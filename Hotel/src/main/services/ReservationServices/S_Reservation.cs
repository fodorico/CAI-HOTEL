using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services.ReservationServices;

public class S_Reservation
{
    public List<Reservation> GetReservationsData(string id)
    {
        return new D_Reservation().Load(id);
    }

    public List<Reservation> GetAllReservation()
    {
        var lr = new D_Reservation().Load();
        return lr.OrderByDescending(o => o.Id).ToList();
    }
}