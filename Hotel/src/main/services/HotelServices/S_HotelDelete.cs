using Hotel.main.dao;
using Hotel.main.entity;


namespace Hotel.main.services.HotelServices;

public class S_HotelDelete
{
    public ResultTransaction DeleteHotelesData(entity.Hotel h)
    {
        return new D_Hotel().Delete(h);
    }
}