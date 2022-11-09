using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Map
{
    [Route("api/map/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<FormDTO> forms = new();
            foreach (var form in _formService.GetAll())
            {
                forms.Add(new FormDTO(form));
            }
            return Ok(forms);
        }

        [HttpGet("get/data/form")]
        public IActionResult GetInformationsOfRooms(int id)
        {
            var forms = _formService.GetInformationsOfRooms(id);
            if (forms == null)
            {
                return NotFound();
            }

            return Ok(forms);
        }
    }
}
