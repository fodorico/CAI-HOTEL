using Hotel.main.dao;

namespace Hotel.main.services;

public class S_Hotel
{
    public List<entity.Hotel> GetHotelesData(string id)
    {
        return new D_Hotel().Load(id);
    }
    
    public List<entity.Hotel> GetHoteles()
    {
        return new D_Hotel().Load();
    }
}