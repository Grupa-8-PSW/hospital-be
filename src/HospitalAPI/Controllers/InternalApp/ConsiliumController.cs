using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Mapper;
using HospitalAPI.Responses;
using HospitalAPI.Web.Mapper;
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
    private readonly IMapper<ConsiliumRequest, ConsiliumRequestDTO> _consiliumMapper;

    public ConsiliumController(IConsiliumService consiliumService, IResponseMapper<Consilium, ConsiliumResponse> consiliResponseMapper, IMapper<ConsiliumRequest, ConsiliumRequestDTO> consiliumMapper)
    {
        _consiliumService = consiliumService;
        _consiliumResponseMapper = consiliResponseMapper;
        _consiliumMapper = consiliumMapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_consiliumResponseMapper.ToDto(await _consiliumService.GetAllIncludeDoctors()));
    }

    [HttpPost]
    public ActionResult Create(ConsiliumRequestDTO consiliumRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        ConsiliumRequest consiliumRequest = _consiliumMapper.toModel(consiliumRequestDTO);
        if (consiliumRequest == null)
        {
            return BadRequest("Poruka .....");
        }


        Task<Consilium?> succesTask = _consiliumService.CreateConsiliumByRequest(consiliumRequest);
        Consilium? consilium = succesTask.Result;
        if (consilium == null)
        {
            return BadRequest("Poruka .....");
        }
        return CreatedAtAction("GetById", new { id = consilium.Id }, _consiliumResponseMapper.ToDto(consilium));
    }
}