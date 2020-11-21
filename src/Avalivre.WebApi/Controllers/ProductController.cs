using Avalivre.Application.UserServices;
using Avalivre.Infrastructure.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Avalivre.WebApi.Controllers
{
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
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
