using FluentValidation.Results;
using Hahn.ApplicatonProcess.December2020.Domain.BusinessLogic.Interface;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController:ControllerBase
    {
        private readonly IApplicant _applicant;

        public ApplicantController(IApplicant applicant)
        {
            _applicant = applicant;
        }
        [HttpPost("AddApplicant")]
        public async Task<IActionResult> AddApplicant([FromBody] ApplicantObj user)
        {
            var res =await _applicant.AddApplicant(user);
            if(res.Success)
            {
                return Ok(res);
            }
            
            return BadRequest(res.ValidationResults);
        }
        [HttpGet("GetApplicant/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _applicant.GetApplicant(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpGet("GetAllApplicant")]
        public async Task<IActionResult> GetApplicants()
        {
            var res = await _applicant.GetAllApplicant();
            return Ok(res);
        }
        [HttpPut("UpdateApplicant")]
        public IActionResult Update([FromBody] ApplicantObj user)
        {
           
            var res = _applicant.UpdateApplicant(user);
            if (!res)
            {
                return BadRequest();
            }
                
            return Ok(res);
        }
        [HttpDelete("DeleteApplicant/{id}")]
        public IActionResult DeleteById(int id)
        {
           var res =  _applicant.DeleteApplicant(id);
            if (!res)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
