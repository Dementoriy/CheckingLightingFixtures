using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClientApp.Models;
using ClientApp.Repositories;
using LabsDB.Entity;
using MainApp;

namespace ClientApp.Controllers;

public class HomeController : Controller
{
    private readonly IClientRepositories _clientRepositories;
    public HomeController(IClientRepositories clientRepository)
    {
        _clientRepositories = clientRepository;
    }
    public async Task<IActionResult>  Index()
    {
        return View(new RoomViewModel{Rooms = await _clientRepositories.GetAllRooms()});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task<EmployeeMessage> Auth(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<NewResponse> AddNewLoadedApp(NewRequest request)
    {
        throw new NotImplementedException();
    }
}