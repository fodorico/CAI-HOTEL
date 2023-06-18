using Hotel.main.dao;
using Hotel.main.entity;
using Hotel.main.services.HotelServices;
using Utils;

namespace Hotel.main.services.RoomServices;

public class S_RoomCreate
{
    public void NewHotel(Customer c)
    {
        Console.Clear();
        var idHotel = new S_Room().GetHotel()[0].id;
        var nextId = new S_Room().GetLastIdRoom(idHotel)[0].id + 1;
        var newRoom = new Room(
            nextId,
            idHotel,
            ValidateInput.ValidateInteger("Ingrese el numero de Plazas: ", 0, 6, true),
            ValidateInput.ValidateInteger("Ingrese el Precio: "),
            int.Parse(c.usuario),
            ValidateInput.ValidateString("Ingrese la Categoria: ", "All"),
            ValidateInput.ValidateBoolean("Es Cancelable? (SI / NO): ")
        );
        if (ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI")
        {
            new D_Room().Insert(newRoom);
        }
    }
}