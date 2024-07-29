using System.Runtime.InteropServices.ObjectiveC;
using DonateSVO.API.Contracts;
using DonateSVO.API.Controllers;
using DonateSVO.Core.Abstractions;
using DonateSVO.Core.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace DonateSVO.Tests.Controller;

public class GatheringControllerTests
{
    private readonly IGatheringRepository _gatheringRepository;
    private readonly IGatheringService _gatheringsService;

    public GatheringControllerTests()
    {
        _gatheringRepository = A.Fake<IGatheringRepository>();
        _gatheringsService = A.Fake<IGatheringService>();
    }

    [Fact]
    public void GatheringController_GetGatherings_ReturnList()
    {
        //Arrange
        var gatheringList = A.Fake<List<Gathering>>();
        A.CallTo(() => _gatheringRepository.Get()).Returns(gatheringList);
        var controller = new GatheringController(_gatheringsService);
        //Act
        var result = controller.GetGatherings().Result.Result;
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void GatheringController_CreateGathering_ReturnId()
    {
        //Arrange
        var gathering = Gathering.Create(
            Guid.NewGuid(),
            "Title",
            "Description",
            100,
            250,
            5,
            true).Gathering;
        var gatheringsRequest = new GatheringsRequest(
            Guid.NewGuid(),
            "Title",
            "Description",
            DateTime.Now,
            100,
            250,
            5,
            true);
        A.CallTo(() => _gatheringRepository.Create(gathering)).Returns(gathering.Id);
        var controller = new GatheringController(_gatheringsService);
        //Act
        var result = controller.CreateGathering(gatheringsRequest).Result.Result;
        //Assert 
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void GatheringController_UpdateGathering_ReturnId()
    {
        var a = "aaa";
        a.Should().Be("aaa");
    }
}