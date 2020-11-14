using Avalivre.Infrastructure.DTO.UserAuth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Avalivre.WebApi.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(
            [FromServices] IUserService userService,
            [FromBody] RegisterUserDTO dto)
        {
            try
            {
                userService.RegisterUser(dto);

                return CreatedAtAction("register", dto.Name);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
