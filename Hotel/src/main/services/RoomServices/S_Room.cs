using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.services.HotelServices;
using Hotel.main.utils;

namespace Hotel.main.services.RoomServices;

public class S_Room
{
    private List<Room> GetRoomData(string id)
    {
        return new D_Room().Load(id);
    }
    
    public List<Room> GetLastIdRoom(int idHotel)
    {
        var lr = new S_Room().GetRoomData(idHotel.ToString());
        return lr.OrderByDescending(o => o.id).ToList();
    }

    public List<Room> GetSpecificRooms(List<entity.Hotel> hotels, List<Reservation> reservations)
    {
        var listRooms = new List<int>();
        listRooms.AddRange(reservations.Select(r => r.idHabitacion));
        return hotels.Select(h => new S_Room().GetRoomData(h.id.ToString())).SelectMany(temp =>
                from ha in temp let temp2 = listRooms.FirstOrDefault(t => t == ha.id) where temp2 != null select ha)
            .ToList();
    }

    public Room SelectIdRoom()
    {
        var result = new Room();
        var express = true;
        while (express)
        {
            result = GetRoomSelected(new S_Hotel().SelectIdHotel());
            if (!string.IsNullOrEmpty(result.categoria))
            {
                express = false;
            }
        }

        return result;
    }

    private Room GetRoomSelected(entity.Hotel hotel)
    {
        var lr = new S_Room().GetRoomData(hotel.id.ToString());
        var max = 0;
        Console.WriteLine("══════════════════════════════════════════════════════");
        foreach (var h in lr)
        {
            max = max > h.id ? max : h.id;
            new S_RoomView().ShowDataRoom(h);
        }

        if (lr.Count > 0)
        {
            var roomSelected = new Room();
            var ops = true;
            while (ops)
            {
                var hId = ValidateInput.ValidateInteger("Coloque el Código de la Habitación deseada: ", -1, max + 1,
                    true);
                foreach (var h in lr.Where(h => h.id == hId))
                {
                    roomSelected = h;
                    ops = false;
                }

                if (ops)
                {
                    Console.WriteLine("Coloque un Código de Habitación correcto y existente");
                }
            }

            return roomSelected;
        }
        else
        {
            Console.WriteLine("Disculpe los inconvenientes para el Hotel seleccionado no hay Habitaciones.");
            return new Room();
        }
    }
}