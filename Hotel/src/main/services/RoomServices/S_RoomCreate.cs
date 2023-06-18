using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.services.HotelServices;
using Hotel.main.utils;

namespace Hotel.main.services.RoomServices;

public class S_RoomCreate
{
    public void NewHotel(Customer c)
    {
        Console.Clear();
        var idHotel = new S_Hotel().SelectIdHotel().id;
        var nextId = new S_Room().GetLastIdRoom(idHotel)[0].id + 1;
        Console.Clear();
        var newRoom = new Room(
            nextId,
            idHotel,
            ValidateInput.ValidateInteger("Ingrese el numero de Plazas: "),
            ValidateInput.ValidateInteger("Ingrese el Precio: "),
            int.Parse(c.usuario),
            ValidateInput.ValidateString("Ingrese la Categoria: "),
            ValidateInput.ValidateBoolean("Es Cancelable? (Si / No): ")
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Room().Insert(newRoom);
        }
    }
}