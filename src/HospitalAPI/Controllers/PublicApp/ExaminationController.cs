using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        [HttpGet("/recommend")]
        public ActionResult<List<DateRange>> GetRecommendedExaminationTime(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to,
            [FromQuery] int doctorId, 
            [FromQuery] AppointmentPriority priority)
        {
            if (from >= to)
                return BadRequest();
            throw new NotImplementedException();
        }
    }
}
