using Hotel.main.dao;
using Hotel.main.entity;

namespace Hotel.main.services;

public class S_Cliente
{
    public Cliente GetClientData(int id)
    {
        return new D_Cliente().Select(id.ToString());
    }
}