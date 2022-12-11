using AgentWorker.Repositories;
using MainApp;

namespace AgentApp;

public class Worker
{
    private readonly IAgentRepository _agentRepository;

    public Worker(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }
    public async Task<EmployeeMessage> Auth(AuthRequest request)
    {
        throw new NotImplementedException();
    }
    public async Task<NewResponse> AddNewLamp(NewRequest request)
    {
        throw new NotImplementedException();
    }
}