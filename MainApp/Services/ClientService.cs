using LabsDB.Entity;
using MainApp.Interfaces;

namespace MainApp.Services;

public class ClientService : IClientService
{
    private ApplicationContext _context;

    public ClientService(ApplicationContext context)
    {
        _context = context;
    }
    public IEnumerable<Room> GetAllRooms()
    {
        throw new NotImplementedException();
    }
}