using HospitalAPI.Connections;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class BloodOrderController : ControllerBase
    {
        private readonly IBloodOrderHTTPConnection _bloodOrderHTTPConnection;

        private readonly IMapper<MonthlySubscription, BloodOrderDTO> _bloodOrderMapper;

        BloodOrderController(IBloodOrderHTTPConnection bloodOrderHTTPConnection, IMapper<MonthlySubscription, BloodOrderDTO> bloodOrderMapper) {
            _bloodOrderHTTPConnection = bloodOrderHTTPConnection;
            _bloodOrderMapper = bloodOrderMapper;
        }


        [HttpGet("{bloodType}")]
        public ActionResult GetAll(string bloodType)
        {
            BloodType bloodTypeValidated;
            if (!Enum.TryParse<BloodType>(bloodType, out bloodTypeValidated))
                return BadRequest("Not valid blood type");

            IEnumerable<MonthlySubscription> monthlySubscriptions = _bloodOrderHTTPConnection.GetBloodOrderByBloodType(bloodTypeValidated);

            IEnumerable<BloodOrderDTO> respond = ((BloodOrderMapper)_bloodOrderMapper).toDTOBloodType(monthlySubscriptions, bloodTypeValidated);

            return Ok(respond);
        }
    }
}
