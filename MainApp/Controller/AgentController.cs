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

    public override Task<EmployeeMessage> Auth(AuthRequest request, ServerCallContext context)
    {
        var e = _agentService.AuthEmployee(request.Login, request.Password);
        if (e is null) return Task.FromResult(new EmployeeMessage());
        return Task.FromResult(new EmployeeMessage
        {
            Id = e.Id, Login = e.Login, Password = e.Password
        });
    }

    public override Task<NewResponse> AddNewLamp(NewRequest request, ServerCallContext context)
    {
        var r = new Lamp(request.Glows, request.Time.ToDateTime() , _agentService.GetRoomById(request.Room));
        return Task.FromResult(new NewResponse
        {
            Res = _agentService.AddNewLamp(r)
        });
    }
}