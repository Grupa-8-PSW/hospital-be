using IntegrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTeamTests.Setup
{
    public class BaseIntegrationTests : IClassFixture<TestDatabaseFactory<Startup>>
    {
        private TestDatabaseFactory<HospitalAPI.Startup> factory;

        protected TestDatabaseFactory<Startup> Factory { get; }

        public BaseIntegrationTests(TestDatabaseFactory<Startup> databaseFactory)
        {
            Factory = databaseFactory;
        }

        public BaseIntegrationTests(TestDatabaseFactory<HospitalAPI.Startup> factory)
        {
            this.factory = factory;
        }
    }
}