using Hotel.main.dao;

namespace Hotel.main.services.HotelServices;

public class S_Hotel
{
    public List<entity.Hotel> GetHotelesData(string id)
    {
        return new D_Hotel().Load(id);
    }

    public List<entity.Hotel> GetAllHoteles()
    {
        var lh = new D_Hotel().Load();
        return lh.OrderByDescending(o => o.Id).ToList();
    }
}