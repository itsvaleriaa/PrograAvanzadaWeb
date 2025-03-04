using Abstractions.Interfaces.API;
using Abstractions.Interfaces.BW;
using Abstractions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = "1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, IProductsController
    {
        private IProductsBW _productsBW;

        public ProductsController(IProductsBW productsBW)
        {
            _productsBW = productsBW;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductsRequest products)
        {
            try
            {
                var result = await _productsBW.Add(products);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpDelete("Eliminar/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            try
            {
                var result = await _productsBW.Delete(Id);
                if (result == Guid.Empty)
                    return BadRequest("Resource not found.");
                return NoContent();
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _productsBW.Get();
                if (!result.Any())
                    return NoContent();
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("Obtener/{Id}")]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            try
            {
                var result = await _productsBW.Get(Id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Products products)
        {
            try
            {
                var result = await _productsBW.Update(products);
                if (result == Guid.Empty)
                    return BadRequest("Resource not found.");
                return NoContent();
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}
