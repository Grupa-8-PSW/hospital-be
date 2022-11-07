using IntegrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTeamTests.Setup
{
    public class BaseIntegrationTests: IClassFixture<TestDatabaseFactory<Startup>>
    {
        protected TestDatabaseFactory<Startup> Factory { get; }

        public BaseIntegrationTests(TestDatabaseFactory<Startup> databaseFactory)
        {
            Factory = databaseFactory;
        }
    }
}
