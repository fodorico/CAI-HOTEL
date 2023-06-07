using System.Collections.Specialized;
using Hotel.main.dao;
using Utils;

namespace Hotel.main.services;

public class S_HotelMenu
{
    public void HotelMenu(entity.Hotel h)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            ShowDataHotel(h);
            opt = SwitchMenuHotel(ShowMenuHotel(), h);
        }
    }

    public void HotelMenu(List<entity.Hotel> h)
    {
        var opt = true;
        while (opt)
        {
            Console.Clear();
            ShowData();
            foreach (var hotel in h)
            {
                ShowDataHotel(hotel);
            }

            var cod = ValidateInput.ValidateInteger("Por favor escriba el Código del Hotel que desea modificar: ", 0,
                999, true);
            opt = SwitchMenuHotel(ShowMenuHotel(), h.FirstOrDefault(t => t.id == cod));
        }
    }

    private void ShowData()
    {
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════════════");
        Console.WriteLine("                    Detalle Hotel                   ");
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    private static void ShowDataHotel(entity.Hotel h)
    {
        Console.WriteLine("     Código: " + h.id);
        Console.WriteLine("     Nombre: " + h.nombre);
        Console.WriteLine("     Estrellas: " + h.estrellas);
        Console.WriteLine("     Direccion: " + h.direccion);
        Console.WriteLine("     Comodidades: " + (h.amenities ? "Sí" : "No"));
        Console.WriteLine("══════════════════════════════════════════════════════");
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
                h.nombre = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempN : h.nombre;
                break;
            case 2:
                var tempE = ValidateInput.ValidateInteger("Ingrese la nueva cantidad de Estrellas: ", -1, 6, true);
                h.estrellas = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempE : h.estrellas;
                break;
            case 3:
                var tempDi = ValidateInput.ValidateString("Ingrese la nueva Dirección: ");
                h.direccion = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempDi : h.direccion;
                break;
            case 4:
                var tempA = ValidateInput.ValidateBoolean("Ingrese si tiene Comodidades (Si/No): ");
                h.amenities = ValidateInput.Confirm(ValidateInput.ConfirmMessage) == "SI" ? tempA : h.amenities;
                break;
            default:
                return false;
        }

        new D_Hotel().Update(h);
        return true;
    }
}