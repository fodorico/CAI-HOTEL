using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services.RoomServices;

public class S_Room
{
    public List<Room> GetRoomData(string id)
    {
        return new D_Room().Load(id);
    }

    public List<Room> GetSpecificRooms(List<entity.Hotel> hotels, List<Reservation> reservations)
    {
        var listRooms = new List<int>();
        listRooms.AddRange(reservations.Select(r => r.idHabitacion));

        // foreach (var ra in hotels.Select(h => new S_Room().GetRoomData(h.Id.ToString())).SelectMany(temp =>
        //              from ha in temp
        //              let temp2 = listRooms.FirstOrDefault(t => t == ha.Id)
        //              where temp2 != null
        //              select ha))
        // {
        //     result.Add(ra);
        // }

        return hotels.Select(h => new S_Room().GetRoomData(h.id.ToString())).SelectMany(temp =>
                from ha in temp let temp2 = listRooms.FirstOrDefault(t => t == ha.id) where temp2 != null select ha)
            .ToList();
    }

    public List<Room> GetAllRoom()
    {
        // var lh = new S_Hotel().GetHoteles();
        // Loop
        // Elegir el hotel
        // Verificar si tiene la cantidad necesiario de espacio para alguna habitacion
        // !Loop
        return new List<Room>();
    }

    public int SelectIdRoom()
    {
        return 0;
    }
}