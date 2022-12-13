using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Security;
using HospitalAPI.Security.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(AuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [EnableCors("InternAllow")]
        [HttpPost("intern/login")]
        public async Task<ActionResult> LoginIntern(LoginRequest loginRequest)
        {
            var token = await _authService.LoginInternAsync(loginRequest);
            if (token == null)
                return BadRequest();
            return Ok(new LoginResponse()
            {
                Jwt = token
            });
        }

        [EnableCors("PublicAllow")]
        [HttpPost("public/login")]
        public async Task<ActionResult> LoginPublic(LoginRequest loginRequest)
        {
            var token = await _authService.LoginPublicAsync(loginRequest);
            if (token == null)
                return BadRequest();
            return Ok(new LoginResponse()
            {
                Jwt = token
            });
        }
        [EnableCors("InternAllow")]
        [HttpPut("manageAccess/{type}/{email}")]
        public async Task<ActionResult> BlockPatientAccess(string type,string email)
        {
            var token = await _authService.BlockUserAccess(type,email);
            if (token == false)
                return BadRequest();
            return Ok();
        }
        [EnableCors("InternAllow")]
        [HttpGet("MaliciousPatients/{type}")]
        public async Task<ActionResult> MaliciousPatients(string type)
        {
            bool blocked;
            if (type.Equals("blocked")) blocked = true;
            else blocked = false;
            return Ok(_mapper.Map<List<PatientDTO>>(_authService.GetBlockedPatients(blocked).Result));
        }
        [EnableCors("PublicAllow")]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest registerRequest)
        {
            var ok = await _authService.RegisterAsync(registerRequest);
            if(ok == null)
                return BadRequest();

            return Ok();
        }

        [HttpGet("validate")]
        [Authorize]
        public IActionResult ValidateAuth()
        {
            return Ok();
        }

    }
}
