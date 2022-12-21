using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public ActionResult<List<Ad>> Get()
        {
            var ads = _adService.GetAll();
            foreach (var ad in ads)
            {
                var path = Path.Combine("images", "ads", ad.ImagePath);
                ad.ImagePath = path;
            }
            return Ok(ads);
        }

    }
}
