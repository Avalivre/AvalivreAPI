using Avalivre.Application.ReviewServices;
using Avalivre.Infrastructure.DTO.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Yaba.Tools.Validations;

namespace Avalivre.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(
            [FromServices] IReviewService reviewService,
            [FromBody] CreateReviewDTO dto)
        {
            try
            {
                dto.UserId = GetUserFromToken();
                var response = await reviewService.Create(dto);

                return Ok(response);
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

        #region Priv Methods
        private int GetUserFromToken()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);

            Validate.NotNull(claim, "É necessário estar logado para acessar este recurso.");

            return int.Parse(claim.Value);
        }
        #endregion
    }
}
