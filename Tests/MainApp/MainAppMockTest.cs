using System;
using System.Collections.Generic;
using System.Linq;
using LabsDB.Entity;
using MainApp;
using MainApp.Controller;
using MainApp.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests.MainApp;

public class MainAppMockTest
{
    private readonly IEnumerable<Room> _testRoom;

    public MainAppMockTest()
    {
        var testRoom = new List<Room>();
        var e = new Employee {Id = 1, Login = "123", Password = "123"};
        for (var i = 1; i < 3; i++)
        {
            var room = new Room {Id = i};
            var ind0 = new Lamp(true, DateTime.Now, room);
            room.Lamps.Add(ind0);
            testRoom.Add(room);
        }

        _testRoom = testRoom;
    }

    [Test]
    public void GetAllRoomSuccess()
    {
        var mock = new Mock<IClientService>();
        mock.Setup(r => r.GetAllRooms()).Returns(_testRoom);
        var clientController = new ClientController(mock.Object);
        var result = clientController.GetRoom();
        Assert.That(result.Count(), Is.EqualTo(_testRoom.Count()));
    }

    [Test]
    public void AddNewLampSuccess()
    {
        var mock = new Mock<IAgentService>();
        mock.Setup(r => r.AddNewLamp(It.IsNotNull<Lamp>())).Returns(true);
        var agentController = new AgentController(mock.Object);
        var res = agentController.AddNewLamp(new NewRequest());
        Assert.That(res, Is.True);
    }

    [Test]
    public void AddNewLampWithNull()
    {
        var mock = new Mock<IAgentService>();
        mock.Setup(r => r.AddNewLamp(It.IsNotNull<Lamp>())).Returns(true);
        var agentController = new AgentController(mock.Object);
        var res = agentController.AddNewLamp(null);
        Assert.That(res, Is.False);
    }

    [Test]
    public void AddNewLampWithErrorRoom()
    {
        var mock = new Mock<IAgentService>();
        mock.Setup(r => r.AddNewLamp(It.Is<Lamp>(i => i.RoomId > 0))).Returns(true);
        var agentController = new AgentController(mock.Object);
        var res = agentController.AddNewLamp(new NewRequest{Room = -1});
        Assert.That(res, Is.False);
    }

    // [Test]
    // public void AddNewIndicationWithErrorEmployee()
    // {
    //     var mock = new Mock<IAgentService>();
    //     mock.Setup(r => r.AddNewLamp(It.Is<Lamp>(i => i.EmployeeId > 0))).Returns(true);
    //     var agentController = new AgentController(mock.Object);
    //     var res = agentController.AddNewLamp(new NewRequest {NowEmployee = -1});
    //     Assert.That(res, Is.False);
    // }

    [Test]
    public void AddNewLampWithGlowsFalse()
    {
        var mock = new Mock<IAgentService>();
        mock.Setup(r => r.AddNewLamp(It.Is<Lamp>(i => i.Glows))).Returns(true);
        var agentController = new AgentController(mock.Object);
        var res = agentController.AddNewLamp(new NewRequest {Glows = false});
        Assert.That(res, Is.False);
    }
    
    // [Test]
    // public void AddNewLampForYesterday()
    // {
    //     var mock = new Mock<IAgentService>();
    //     mock.Setup(r => r.AddNewLamp(It.Is<Lamp>(i => i.TimeStamp == DateTime.Now))).Returns(true);
    //     var agentController = new AgentController(mock.Object);
    //     var res = agentController.AddNewLamp(new NewRequest {Time != DateTime.Now});
    //     Assert.That(res, Is.False);
    // }

    [Test]
    public void AuthSuccess()
    {
        var mock = new Mock<IAgentService>();
        mock.Setup(r => r.AuthEmployee(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(new Employee {Id = 1, Login = "123", Password = "123"});
        var agentController = new AgentController(mock.Object);
        var res = agentController.Auth(new AuthRequest{Login = "123", Password = "123"});
        Assert.That(res, Is.Not.Null);
    }

    [TestCase("   ", "123")]
    [TestCase("123", "    ")]
    [TestCase("   ", "    ")]
    [TestCase(null, "123")]
    [TestCase("123", null)]
    [TestCase(null, null)]
    public void AuthWithErrorData(string login, string password)
    {
        var mock = new Mock<IAgentService>();
        mock.Setup(r => r.AuthEmployee(It.Is<string>(s => !string.IsNullOrWhiteSpace(s)),
                It.Is<string>(s => !string.IsNullOrWhiteSpace(s))))
            .Returns(new Employee {Id = 1, Login = "123", Password = "123"});
        var agentController = new AgentController(mock.Object);
        var res = agentController.Auth(new AuthRequest{Login = login, Password = password});
        Assert.That(res, Is.Null);
    }
}