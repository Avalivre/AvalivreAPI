using Avalivre.Application.UserServices;
using Avalivre.Infrastructure.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Yaba.Tools.Validations;

namespace Avalivre.WebApi.Controllers
{
    [EnableCors]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(
            [FromServices] IProductService productService,
            [FromBody] CreateProductDTO dto)
        {
            try
            {
                var response = await productService.Create(dto);

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

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetSimilarProducts(
            [FromQuery] string name,
            [FromServices] IProductService productService)
        {
            try
            {
                var response = await productService.GetSimilarProducts(name);

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

        [AllowAnonymous]
        [HttpGet("{id}")]
        [Route("")]
        public async Task<IActionResult> GetProduct(
            long id,
            [FromServices] IProductService productService)
        {
            try
            {
                var response = await productService.Get(id);

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

        [HttpDelete("{id}")]
        [Route("")]
        public async Task<IActionResult> DeleteProduct(
            long id,
            [FromServices] IProductService productService)
        {
            try
            {
                var userId = GetUserFromToken();
                await productService.Delete(id, userId);

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

        [HttpPut("{id}")]
        [Route("")]
        public async Task<IActionResult> UpdateProduct(
            long id,
            [FromBody] UpdateProductDTO dto,
            [FromServices] IProductService productService)
        {
            try
            {
                dto.Id = id;
                var userId = GetUserFromToken();
                await productService.Edit(dto, userId);

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
