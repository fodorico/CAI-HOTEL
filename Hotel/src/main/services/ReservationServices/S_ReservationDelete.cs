using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services.ReservationServices;

public class S_ReservationDelete
{
    // TODO: Falta el menu de la eliminacion
    public ResultTransaction DeleteReservationsData(Reservation r)
    {
        return new D_Reservation().Delete(r);
    }
}