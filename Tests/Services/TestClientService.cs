using System.Collections.Generic;
using System.Linq;
using LabsDB.Entity;
using MainApp.Interfaces;

namespace Tests.Services;

public class TestClientService : IClientService
{
    public IEnumerable<Room> GetAllRooms()
    {
        return Enumerable.Range(0, 2).Select(_ => new Room());
    }
}