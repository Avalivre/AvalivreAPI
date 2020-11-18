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
                var response = productService.Create(dto);

                return response;
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }
    }
}
