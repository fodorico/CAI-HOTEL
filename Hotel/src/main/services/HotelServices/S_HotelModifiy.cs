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
            opt = SwitchAndValidate(h);
        }
    }

    private bool SwitchAndValidate(List<entity.Hotel> h)
    {
        entity.Hotel hot;
        while (true)
        {
            var cod = ValidateInput.ValidateInteger("Por favor escriba el Código del Hotel que desea modificar: ", 0,
                999, true);
            hot = h.FirstOrDefault(t => t.id == cod);
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
                SetNewName(ref h);
                break;
            case 2:
                SetNewStars(ref h);
                break;
            case 3:
                SetNewAddress(ref h);
                break;
            case 4:
                SetNewAmenities(ref h);
                break;
            default:
                return false;
        }

        new D_Hotel().Update(h);
        return false;
    }

    private static void SetNewName(ref entity.Hotel h)
    {
        var tempN = ValidateInput.ValidateString("Ingrese el nuevo Nombre: ", "IsLetter");
        h.nombre = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempN : h.nombre;
    }

    private static void SetNewStars(ref entity.Hotel h)
    {
        var tempE = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Estrellas: ", -1, 6, true);
        h.estrellas = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempE : h.estrellas;
    }

    private static void SetNewAddress(ref entity.Hotel h)
    {
        var tempDi = ValidateInput.ValidateString("Ingrese la nueva Dirección: ");
        h.direccion = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempDi : h.direccion;
    }

    private static void SetNewAmenities(ref entity.Hotel h)
    {
        var tempA = ValidateInput.ValidateBoolean("Ingrese si tiene Comodidades (Si/No): ");
        h.amenities = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempA : h.amenities;
    }
}