using Hotel.main.entity;
using Newtonsoft.Json;

namespace Hotel.main.abstraction;

public class A_JsonConvert<T>
{
    protected List<T> StringToJsonArray(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    protected T StringToJsonObject(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    protected ResultTransaction StringToJsonObjectTransaccion(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<ResultTransaction>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}