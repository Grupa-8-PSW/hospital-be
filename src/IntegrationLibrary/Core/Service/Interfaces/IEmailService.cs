using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;
using MimeKit;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string emailBB, string password, string API);
        void SendSuccessEmail(string emailBB, int tenderId, string APIKey);
        void SendRejectEmail(string emailBB);

        void SendRejectMonthlyDeliveryEmail(string emailBB);
        void sendPDFReportAttached(byte[] myFileAsByteArray);
    }
}
