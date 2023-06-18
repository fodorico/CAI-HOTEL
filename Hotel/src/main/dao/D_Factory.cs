using Hotel.main.entity;

namespace Hotel.main.dao;

public interface D_Factory<T>
{
    List<T> Load();
    List<T> Load(string id);
    T Select(string id);
    ResultTransaction Insert(T data);
    ResultTransaction Update(T data);
    ResultTransaction Delete(T data);
}