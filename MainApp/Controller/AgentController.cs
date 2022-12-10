using MainApp.Interfaces;
using Grpc.Core;
using LabsDB.Entity;

namespace MainApp.Controller;

public class AgentController : Agent.AgentBase
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    public EmployeeMessage Auth(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public override Task<EmployeeMessage> Auth(AuthRequest request, ServerCallContext context)
    {
        return Task.FromResult(Auth(request));
    }
    public NewResponse AddNewLamp(NewRequest lamp)
    {
        throw new NotImplementedException();
    }
    public override Task<NewResponse> AddNewLamp(NewRequest request, ServerCallContext context)
    {
        return Task.FromResult(AddNewLamp(request));
    }
    
}