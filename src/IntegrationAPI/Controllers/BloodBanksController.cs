﻿using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using IntegrationAPI.ExceptionHandler.Validators;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBanksController : ControllerBase
    {
        private readonly IBloodBankService _bloodBankService;
        private readonly IEmailService _emailService;
        private readonly ICredentialGenerator _credentialGenerator;
        
        
        public BloodBanksController(IBloodBankService bloodBankService1)
        {
            this._bloodBankService = bloodBankService1;
        }


        // GET: api/bloodBanks
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodBankService.GetAll());
        }

        // POST api/bloodBanks
        [HttpPost]
        public ActionResult Create([FromBody] BloodBankDTO bloodBankDTO)
        {
            BloodBankValidator.Validate(bloodBankDTO);

            string password = _credentialGenerator.GeneratePassword();
            string api = _credentialGenerator.GenerateAPI();

            BloodBank bloodBank = new BloodBank(bloodBankDTO.Name, bloodBankDTO.Email, bloodBankDTO.ServerAddress, password, api);

            _bloodBankService.Create(bloodBank);
            _emailService.SendEmail(bloodBank.Email, bloodBank.Password, bloodBank.APIKey);
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var bloodBank = _bloodBankService.GetById(id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            _bloodBankService.Delete(bloodBank);
            return NoContent();
        }

    }
}
