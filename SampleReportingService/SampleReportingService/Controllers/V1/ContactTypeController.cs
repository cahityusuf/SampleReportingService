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
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeService _contactTypeService;

        public ContactTypeController(IContactTypeService contactTypeService)
        {
            _contactTypeService = contactTypeService;
        }

        [HttpGet("GetByIdAsync/{id:long}")]
        [ProducesResponseType(typeof(ContactTypeDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _contactTypeService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetListAsync")]
        [ProducesResponseType(typeof(List<ContactTypeDto>), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _contactTypeService.GetListAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }

        [HttpPost("InsertAsync")]
        [ProducesResponseType(typeof(ContactTypeDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> InsertAsync(ContactTypeDto contactType)
        {
            var result = await _contactTypeService.InsertAsync(contactType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("UpdateAsync")]
        [ProducesResponseType(typeof(ContactTypeDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(ContactTypeDto contactType)
        {
            var result = await _contactTypeService.UpdateAsync(contactType);

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
            var result = await _contactTypeService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
