﻿using HospitalAPI.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalAPI.Security
{
    public class AuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            SignInManager<User> signInManager, 
            RoleManager<IdentityRole<int>> roleManager,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            if (user == null)
                return null;
            var res = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!res)
                return null;
            return BuildToken(await GetUserDTO(user));
        }

        public async Task SeedAsync()
        {
            /*var user = new User()
            {
                UserName = "test",
                Email = "test@test.com"
            };
            await _userManager.CreateAsync(user, "12345");
            _userManager.AddToRoleAsync(user, "Patient");

            var user = new User()
            {
                UserName = "doctor",
                Email = "doctor@doctor.com"
            };
            await _userManager.CreateAsync(user, "12345");
            _userManager.AddToRoleAsync(user, "Doctor");*/

            var user = new User()
            {
                UserName = "manager",
                Email = "manager@manager.com"
            };
            await _userManager.CreateAsync(user, "12345");
            _userManager.AddToRoleAsync(user, "Manager");
        }

        private async Task<UserDTO> GetUserDTO(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return new UserDTO()
            {
                Username = user.UserName,
                Role = userRoles[0]
            };
        }

        private string BuildToken(UserDTO user)
        {
            var issuer = _configuration["Jwt:ValidIssuer"];
            var secret = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Username", user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}