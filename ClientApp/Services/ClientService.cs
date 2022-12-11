using ClientApp.Repositories;
using LabsDB.Entity;

namespace ClientApp.Services;

public class ClientService:IClientRepositories
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public Task<IEnumerable<Room>> GetAllRooms()
    {
        throw new NotImplementedException();
    }
}