using Avalivre.Application.UserServices;
using Avalivre.Infrastructure.DTO.UserAuth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Avalivre.WebApi.Controllers
{
    [Route("api/[controller]")]
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
                // TODO: retornar informações sobre o usuário logado
                await userService.Register(dto);

                return Ok();
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Login(
            [FromServices] IUserService userService,
            [FromBody] LoginUserDTO dto)
        {
            try
            {
                var result = await userService.Login(dto);

                return Ok(result);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
