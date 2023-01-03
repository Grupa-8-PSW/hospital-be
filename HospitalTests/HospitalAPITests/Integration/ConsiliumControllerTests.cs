using AngleSharp.Io;
using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers.InternalApp;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;
using HospitalAPI.Responses;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace HospitalTests.HospitalAPITests.Integration;

public class ConsiliumControllerTests : BaseIntegrationTest
{
    public ConsiliumControllerTests(TestDatabaseFactory<Startup> factory) : base(factory)
    {

    }

    private static ConsiliumController SetupController(IServiceScope scope)
    {
        return new ConsiliumController(
            scope.ServiceProvider.GetRequiredService<IConsiliumService>(),
            scope.ServiceProvider.GetRequiredService<IResponseMapper<Consilium, ConsiliumResponse>>(),
            scope.ServiceProvider.GetRequiredService<IMapper<ConsiliumRequest, ConsiliumRequestDTO>>()
        );
    }

    [Fact]
    public async void ConsiliumController_GetsAllConsiliumsFromDatabase()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var consiliumController = SetupController(scope);
        var consiliumsResponses = getConsiliumResponse();

        // Act
        var response = await consiliumController.GetAll();

        // Assert
        var okResponse = response.ShouldBeOfType<OkObjectResult>();
        var consiliums = okResponse.Value.ShouldBeOfType<List<ConsiliumResponse>>();
        consiliums.ShouldNotBeNull();
        consiliums.ShouldBeEquivalentTo(consiliumsResponses);
    }

    private List<ConsiliumResponse> getConsiliumResponse()
    {
        var consiliumResponses = new List<ConsiliumResponse>();
        consiliumResponses.Add(new ConsiliumResponse
        {
            Id = 1,
            Subject = "Consilium 1",
            Duration = 90,
            From = "12/20/2022 14:30:00",
            To = "12/30/2022 17:22:00",
            Doctors = new List<ConsiliumDoctorResponse>()
        });
        consiliumResponses.Add(new ConsiliumResponse
        {
            Id = 2,
            Subject = "Consilium 2",
            Duration = 40,
            From = "01/03/2023 09:30:00",
            To = "02/23/2023 13:22:00",
            Doctors = new List<ConsiliumDoctorResponse>()
        });

        return consiliumResponses;
    }

    [Fact]
    public async void Creates_consilium_avaivable_by_doctors()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);


        var responseAllCinsukumBefore = await (controller.GetAll());

        List<int> doctorsId = new List<int>
        {
            1
        };
        ConsiliumRequestDTO consiliumRequestDTO = new ConsiliumRequestDTO() { Subject = "subect1", FromDate = "13/01/2023", ToDate = "15/01/2023", Duration = 60, IsDoctors = true, DoctorIds = doctorsId, DoctorSpecializationsWanted = null};
        var result = ((CreatedAtActionResult)controller.Create(consiliumRequestDTO))?.Value as ConsiliumResponse;


        var respomseAllConsiliumsAfter = await (controller.GetAll());



        var okResponseBefore = responseAllCinsukumBefore.ShouldBeOfType<OkObjectResult>();
        var consiliumsBefore = okResponseBefore.Value.ShouldBeOfType<List<ConsiliumResponse>>();

        var okResponseAfter = respomseAllConsiliumsAfter.ShouldBeOfType<OkObjectResult>();
        var consiliumsAfter = okResponseBefore.Value.ShouldBeOfType<List<ConsiliumResponse>>();
        Assert.True(consiliumsBefore.Count + 1 == consiliumsAfter.Count);

        result.ShouldNotBeNull();
        var resultVar = result.ShouldBeOfType<OkObjectResult>();
        var consiliumCreated = resultVar.Value.ShouldBeOfType<ConsiliumResponse>();
        Assert.True(consiliumCreated.Doctors.Count() == 1);

        

    }



}