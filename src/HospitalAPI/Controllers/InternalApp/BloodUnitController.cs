using System.Drawing.Text;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class BloodUnitController : ControllerBase
    {
        private readonly IBloodUnitService _bloodUnitService;

        public BloodUnitController(IBloodUnitService bloodUnitService)
        {
            _bloodUnitService = bloodUnitService;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodUnitService.GetAll());
        }
    }
}
