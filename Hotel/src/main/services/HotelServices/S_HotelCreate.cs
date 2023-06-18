using Hotel.main.dao;
using Hotel.main.entity;
using Utils;

namespace Hotel.main.services.HotelServices;

public class S_HotelCreate
{
    public entity.Hotel NewHotel(Customer c)
    {
        Console.Clear();
        var nextId = new S_Hotel().GetAllHoteles()[0].Id + 1;
        var newHotel = new entity.Hotel(
            nextId,
            ValidateInput.ValidateInteger("Ingrese el numero de estrellas: ", 0, 6, true),
            int.Parse(c.User),
            ValidateInput.ValidateBoolean("Tiene Comodidades? (SI / NO): "),
            ValidateInput.ValidateString("Ingrese la Dirección: ", "All"),
            ValidateInput.ValidateString("Ingrese el Nombre: ", "IsLetter")
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Hotel().Insert(newHotel);
        }

        return newHotel;
    }
}