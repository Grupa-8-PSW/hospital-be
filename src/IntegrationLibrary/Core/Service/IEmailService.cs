using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Service
{
    public interface IEmailService
    {
        void SendEmail(string emailBB, string password, string API);
    }
}
