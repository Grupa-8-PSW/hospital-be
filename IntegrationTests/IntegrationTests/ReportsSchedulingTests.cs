using DryIoc;
using IntegrationTeamTests.Setup;
using System;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using HospitalLibrary.Core.Service;

namespace IntegrationTeamTests.Integration
{
    public class ReportsSchedulingTests: BaseIntegrationTests
    {
        public ReportsSchedulingTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodBanksController SetupController(IServiceScope scope)
        {
            return new BloodBanksController(scope.ServiceProvider.GetRequiredService<IRoomService>());
        }

        [Fact]
        public void Test1()
        {


        }
    }
}