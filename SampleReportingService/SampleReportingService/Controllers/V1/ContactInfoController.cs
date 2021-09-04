using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Dtos;
using Abstractions.Services;
using Microsoft.AspNetCore.Authorization;

namespace DirectoryApi.Controllers.V1
{
    [ApiController]
    [Produces("application/json")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet("GetByIdAsync/{id:long}")]
        [ProducesResponseType(typeof(ContactInfoDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _contactInfoService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetListAsync")]
        [ProducesResponseType(typeof(List<ContactInfoDto>), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _contactInfoService.GetListAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }

        [HttpPost("InsertAsync")]
        [ProducesResponseType(typeof(ContactInfoDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> InsertAsync(ContactInfoDto contactInfo)
        {
            var result = await _contactInfoService.InsertAsync(contactInfo);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("UpdateAsync")]
        [ProducesResponseType(typeof(ContactInfoDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(ContactInfoDto contactInfo)
        {
            var result = await _contactInfoService.UpdateAsync(contactInfo);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("DeleteAsync")]
        [ProducesResponseType(typeof(bool), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _contactInfoService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
