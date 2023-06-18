using Hotel.main.dao;
using Utils;

namespace Hotel.main.services.HotelServices;

public class S_HotelModifiy
{
    public void HotelModify(List<entity.Hotel> h)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            opt = ValidateInput.ValidateBoolean("Desea modificar un dato de un Hotel? (Si / No): ")
                ? SwitchAndValidate(h)
                : false;
        }
    }

    private bool SwitchAndValidate(List<entity.Hotel> h)
    {
        entity.Hotel hot;
        while (true)
        {
            var cod = ValidateInput.ValidateInteger("Por favor escriba el Código del Hotel que desea modificar: ", 0,
                999, true);
            hot = h.FirstOrDefault(t => t.Id == cod);
            if (hot != null)
            {
                break;
            }

            Console.WriteLine("Por favor coloque un código valido!");
        }

        return SwitchMenuHotel(ShowMenuHotel(), hot);
    }

    private int ShowMenuHotel()
    {
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Menú Hotel                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("¿Qué datos le gustaría modificar?");
        Console.WriteLine("     1. Nombre");
        Console.WriteLine("     2. Estrellas");
        Console.WriteLine("     3. Dirección");
        Console.WriteLine("     4. Amenities");
        Console.WriteLine("     0. Salir");
        Console.WriteLine("══════════════════════════════════════════════════════");
        return ValidateInput.ValidateInteger("Ingrese la opción deseada: ", -1, 5, true);
    }

    private bool SwitchMenuHotel(int i, entity.Hotel h)
    {
        switch (i)
        {
            case 1:
                var tempN = ValidateInput.ValidateString("Ingrese el nuevo Nombre: ", "IsLetter");
                h.Name = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempN : h.Name;
                break;
            case 2:
                var tempE = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Estrellas: ", -1, 6, true);
                h.Stars = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempE : h.Stars;
                break;
            case 3:
                var tempDi = ValidateInput.ValidateString("Ingrese la nueva Dirección: ");
                h.Address = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempDi : h.Address;
                break;
            case 4:
                var tempA = ValidateInput.ValidateBoolean("Ingrese si tiene Comodidades (Si/No): ");
                h.Amenities = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempA : h.Amenities;
                break;
            default:
                return false;
        }

        new D_Hotel().Update(h);
        return true;
    }
}