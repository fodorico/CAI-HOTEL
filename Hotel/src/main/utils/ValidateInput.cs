using System.Globalization;

namespace Hotel.main.utils;

public static class ValidateInput
{
    public const string ConfirmMessage = "Desea guardar este cambio? (Si / No): ";
    private const string Message = "Por favor, ingrese un valor correcto! ";

    public static string ValidateString(string text, string optional = "All", string[] list = null)
    {
        while (true)
        {
            Console.Write(text);
            var input = Console.ReadLine();
            if (input != null && input.Trim().Length > 0)
            {
                if ((optional == "All" && list == null) ||
                    (optional == "IsLetterOrDigit" && input.All(char.IsLetterOrDigit) && list == null) ||
                    (optional == "IsLetter" && input.All(char.IsLetter) && list == null) ||
                    (optional == "IsDigit" && input.All(char.IsDigit) && list == null) ||
                    (list != null && OptionalList(input, list))
                   )
                {
                    return input;
                }
            }

            //Console.Clear();
            Console.WriteLine(Message + "Coloque un valor que corresponda.");
        }
    }

    private static bool OptionalList(string text, string[] list)
    {
        return list.Aggregate(false, (current, v) => current ? current : v.Equals(text.ToLower()));
    }


    public static int ValidateInteger(string text, int min = 0, int max = 0, bool optional = false)
    {
        while (true)
        {
            Console.Write(text);
            var input = Console.ReadLine();
            if (input != null && input.Trim().Length > 0 && int.TryParse(input, out var result))
            {
                if (!optional || (min < result && result < max))
                {
                    return result;
                }
            }

            //Console.Clear();
            Console.WriteLine(Message + "Coloque un valor que corresponda.");
        }
    }

    public static double ValidateDouble(string text)
    {
        while (true)
        {
            Console.Write(text);
            var input = Console.ReadLine();
            if (input != null && input.Trim().Length > 0 && double.TryParse(input, out var result))
            {
                return result;
            }

            //Console.Clear();
            Console.WriteLine(Message + "Coloque un valor que corresponda.");
        }
    }

    public static DateTime ValidateDateTime(string text, string msg, string condition, DateTime dt)
    {
        while (true)
        {
            Console.Write(text);
            var input = Console.ReadLine();
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    var dateTime = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.CurrentCulture);
                    if ((condition.ToUpper().Equals("LESS") && dateTime < dt) ||
                        (condition.ToUpper().Equals("MORE") && dateTime > dt))
                    {
                        return dateTime;
                    }
                }

                //Console.Clear();
                Console.WriteLine(Message + $"No coloque una fecha vacía, ni tampoco {msg}.");
            }
            catch (Exception)
            {
                //Console.Clear();
                Console.WriteLine(Message + "Coloque un valor tal como se solicitó.");
            }
        }
    }

    public static bool ValidateBoolean(string text)
    {
        while (true)
        {
            Console.Write(text);
            var input = Console.ReadLine()?.ToUpper();
            try
            {
                if (input is "SI" or "NO")
                {
                    return input.Equals("SI");
                }
            }
            catch (Exception)
            {
                //Console.Clear();
                Console.WriteLine(Message + "Coloque un valor que corresponda.");
            }
            Console.WriteLine(Message + "Coloque un valor que corresponda.");
        }
    }

    public static string Confirm(string text)
    {
        while (true)
        {
            Console.Write(text);
            var input = Console.ReadLine()?.ToUpper();
            try
            {
                if (input is "SI" or "NO")
                {
                    return input;
                }
            }
            catch (Exception)
            {
                //Console.Clear();
                Console.WriteLine(Message + "Coloque un valor que corresponda.");
            }
        }
    }
}