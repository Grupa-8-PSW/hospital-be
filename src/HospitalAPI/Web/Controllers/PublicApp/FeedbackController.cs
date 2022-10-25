using HospitalLibrary.Feedback;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Web.Controllers.PublicApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // GET: api/Feedback
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_feedbackService.GetAll());
        }

        // GET: api/Feedback/public
        [HttpGet("/public")]
        public ActionResult GetPublicFeedback()
        {
            return Ok(_feedbackService.GetPublicFeedback());
        }
    }
}
