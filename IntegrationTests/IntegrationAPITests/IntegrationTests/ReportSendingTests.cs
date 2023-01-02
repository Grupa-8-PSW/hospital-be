using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAPI;
using IntegrationAPI.Connections;
using IntegrationLibrary.Core.Model;
using IntegrationTeamTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace IntegrationTests.IntegrationAPITests.IntegrationTests
{
    public class ReportSendingTests: BaseIntegrationTests
    {
        public ReportSendingTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        [Fact]
        public void sendsReport()
        { 
            var mock = new Mock<BloodBankHTTPConnection>();
            String dt = "2022-11-23 19:00:00+01";
            DateTime date = DateTime.Parse(dt);
            var bcc = new BloodConsumptionConfiguration(10, date, TimeSpan.FromHours(3), TimeSpan.FromHours(50));
            mock.Verify(n => n.SendToBanks(DateTime.Now, bcc, TimeSpan.FromSeconds(10)));
        }
    }
}
