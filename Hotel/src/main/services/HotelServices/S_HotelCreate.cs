using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.utils;

namespace Hotel.main.services.HotelServices;

public class S_HotelCreate
{
    public void NewHotel(Customer c)
    {
        Console.Clear();
        var nextId = new S_Hotel().GetAllHoteles()[0].id + 1;
        var newHotel = new entity.Hotel(
            nextId,
            ValidateInput.ValidateInteger("Ingrese el numero de estrellas: ", 0, 6, true),
            int.Parse(c.usuario),
            ValidateInput.ValidateBoolean("Tiene Comodidades? (Si / No): "),
            ValidateInput.ValidateString("Ingrese la Dirección: "),
            ValidateInput.ValidateString("Ingrese el Nombre: ", "IsLetter")
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Hotel().Insert(newHotel);
        }
    }
}