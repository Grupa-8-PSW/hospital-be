using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface ICredentialGenerator
    {
        public string GeneratePassword();
        public string GenerateAPI();
        public string GenerateDummyString(int length);

    }
}
