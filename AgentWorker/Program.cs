using AgentApp;
using AgentApp.Services;
using AgentWorker;
using AgentWorker.Repositories;
using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection().AddTransient<IAgentRepository,AgentService>();

using var serviceProvider = service.BuildServiceProvider();
var worker = new Worker(serviceProvider.GetService<IAgentRepository>()!);
throw new NotImplementedException();