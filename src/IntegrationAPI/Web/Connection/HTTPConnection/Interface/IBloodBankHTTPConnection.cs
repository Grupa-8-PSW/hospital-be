using System.Xml.Serialization;


namespace IntegrationAPI.Web.Connection.HTTPConnection.Interface
{
    public interface IBloodBankHTTPConnection
    {
        public bool BloodQuantityExists(double quantity);
    }
}
