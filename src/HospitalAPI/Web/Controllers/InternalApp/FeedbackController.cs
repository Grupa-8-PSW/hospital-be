using AutoMapper;
using HospitalAPI.Web.DTO;
using HospitalLibrary.Feedback;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Web.Controllers.InternalApp
{
    [Route("api/[controller]")]
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

        // GET: api/Feedback
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<FeedbackDTO>>(_feedbackService.GetAll()));
        }

        [HttpPut("{id}/status")]
        public IActionResult ChangeStatus(int id, FeedbackStatus feedbackStatus)
        {
            _feedbackService.ChangeStatus(id, feedbackStatus);
            return Ok();
        }

    }
}
