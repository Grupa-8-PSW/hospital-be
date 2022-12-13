using HospitalAPI.Mapper;
using HospitalAPI.Responses;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.InternalApp;


[ApiController]
[Route("api/internal/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ConsiliumController : ControllerBase
{
    private readonly IConsiliumService _consiliumService;
    private readonly IResponseMapper<Consilium, ConsiliumResponse> _consiliumResponseMapper;

    public ConsiliumController(IConsiliumService consiliumService, IResponseMapper<Consilium, ConsiliumResponse> consiliResponseMapper)
    {
        _consiliumService = consiliumService;
        _consiliumResponseMapper = consiliResponseMapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_consiliumResponseMapper.ToDto(await _consiliumService.GetAllIncludeDoctors()));
    }
}