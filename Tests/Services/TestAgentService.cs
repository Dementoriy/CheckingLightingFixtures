using System.Collections.Generic;
using System.Linq;
using LabsDB.Entity;
using MainApp.Interfaces;

namespace Tests.Services;

public class TestAgentService : IAgentService
{
    private static readonly Employee _employee = new() { Login = "123", Password = "123" };
    private static readonly List<Room> _rooms = Enumerable.Range(1, 10).Select(r => new Room { Id = r }).ToList();

    public bool AddNewLamp(Lamp lamp)
    {
        if (lamp is null) return false;
        return _rooms.Any(h => h.Id == lamp.RoomId);
    }

    public Employee? AuthEmployee(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) return null;
        if (login == _employee.Login && password == _employee.Password) return _employee;
        return null;
    }

    public Room? GetRoomById(int id)
    {
        return _rooms.FirstOrDefault(h => h.Id == id);
    }

    public Employee? GetEmployeeById(int id)
    {
        return id == _employee.Id ? _employee : null;
    }
}