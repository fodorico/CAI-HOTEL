using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services.RoomServices;

public class S_RoomDelete
{
    // TODO: Falta el menu de la eliminacion
    public ResultTransaction DeleteRoomData(Room r)
    {
        return new D_Room().Delete(r);
    }
    
}