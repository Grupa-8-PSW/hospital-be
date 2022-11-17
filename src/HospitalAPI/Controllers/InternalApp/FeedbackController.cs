using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [Authorize(Roles = "Manager")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            _mapper = mapper;
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<FeedbackDTO>>(_feedbackService.GetAll()));
        }

        [HttpGet("public")]
        public ActionResult GetPublicFeedback()
        {
            return Ok(_mapper.Map<List<FeedbackDTO>>(_feedbackService.GetAllPublic()));
        }

        [HttpPut("{id}/status")]
        public IActionResult ChangeStatus(int id, FeedbackStatus feedbackStatus)
        {
            _feedbackService.ChangeStatus(id, feedbackStatus);
            return Ok();
        }

    }
}
