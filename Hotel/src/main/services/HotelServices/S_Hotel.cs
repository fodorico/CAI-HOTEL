using Hotel.main.dao;
using Hotel.main.utils;

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
        return lh.OrderByDescending(o => o.id).ToList();
    }
    
    public entity.Hotel SelectIdHotel()
    {
        var hotels = ShowHotelsToSelect();
        var express = true;
        var result = new entity.Hotel();
        while (express)
        {
            result = GetHotelSelected(hotels.Item1, hotels.Item2);
            if (!string.IsNullOrEmpty(result.nombre))
            {
                express = false;
            }
        }

        return result;
    }
    
    private (List<entity.Hotel>, int) ShowHotelsToSelect()
    {
        var lh = new S_Hotel().GetAllHoteles();
        var max = 0;
        Console.WriteLine("══════════════════════════════════════════════════════");
        foreach (var h in lh)
        {
            max = max > h.id ? max : h.id;
            new S_HotelView().ShowDataHotel(h);
        }

        return (lh, max);
    }
    
    private static entity.Hotel GetHotelSelected(List<entity.Hotel> lh, int max)
    {
        var hotelSelected = new entity.Hotel();
        var ops = true;
        while (ops)
        {
            var hId = ValidateInput.ValidateInteger("Coloque el Código del Hotel deseado: ", -1, max + 1, true);
            foreach (var h in lh.Where(h => h.id == hId))
            {
                hotelSelected = h;
                ops = false;
            }

            if (ops)
            {
                Console.WriteLine("Coloque un Código de Hotel correcto y existente");
            }
        }

        return hotelSelected;
    }
}