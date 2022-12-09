using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LabsDB.Entity;
using MainApp;
using MainApp.Interfaces;
using MainApp.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Tests.Services;

namespace Tests;

public class Tests
{
    [Test]
    public async Task GetAllRooms()
    {
        using var server = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                ServiceDescriptor serviceDescriptor =
                    new(typeof(IClientService), typeof(ClientService), ServiceLifetime.Transient);
                services.Remove(serviceDescriptor);
                services.AddTransient<IClientService>(_ => new TestClientService());
            });
        });
        using var client = server.CreateClient();
        var res = await client.GetFromJsonAsync<IEnumerable<Room>>("/client/get");
        Assert.That(res.Count(), Is.EqualTo(2));
    }
}