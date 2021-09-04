using Abstractions.Dtos;
using Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectoryApi.Controllers.V1
{
    [ApiController]
    [Produces("application/json")]
    [Route("v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetByIdAsync/{id:long}")]
        [ProducesResponseType(typeof(UserDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetListAsync")]
        [ProducesResponseType(typeof(List<UserDto>), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _userService.GetListAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }

        [HttpPost("InsertAsync")]
        [ProducesResponseType(typeof(UserDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> InsertAsync(UserDto user)
        {
            var result = await _userService.InsertAsync(user);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("UpdateAsync")]
        [ProducesResponseType(typeof(UserDto), statusCode: 200)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(UserDto user)
        {
            var result = await _userService.UpdateAsync(user);

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
            var result = await _userService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
