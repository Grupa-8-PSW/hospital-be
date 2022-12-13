using AngleSharp.Io;
using HospitalAPI;
using HospitalAPI.Controllers.InternalApp;
using HospitalAPI.Mapper;
using HospitalAPI.Responses;
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
            scope.ServiceProvider.GetRequiredService<IResponseMapper<Consilium, ConsiliumResponse>>()
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
}