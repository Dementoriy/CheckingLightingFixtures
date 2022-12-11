using AgentWorker.Repositories;
using MainApp;

namespace AgentApp.Services;

public class AgentService : IAgentRepository
{
    public Task<EmployeeMessage> Auth(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<NewResponse> AddNewLamp(NewRequest request)
    {
        throw new NotImplementedException();
    }
}