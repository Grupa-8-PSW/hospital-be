﻿using HospitalAPI.Security;
using HospitalAPI.Security.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var token = await _authService.LoginAsync(loginRequest);
            if (token == null)
                return BadRequest();
            return Ok(token);
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Seed()
        {
            await _authService.SeedAsync();
            return Ok();
        }
    }
}
