﻿using LabsDB.Entity;
using MainApp.Interfaces;

namespace MainApp.Services;

public class AgentService : IAgentService
{
    public bool AddNewLamp(Lamp lamp)
    {
        throw new NotImplementedException();
    }

    public LabsDB.Entity.Employee? AuthEmployee(string login, string password)
    {
        throw new NotImplementedException();
    }

    public Room? GetRoomById(int id)
    {
        throw new NotImplementedException();
    }

    public Employee? GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }
}