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
    public class ProductsCategoriesController : ControllerBase, IProductsCategoriesController
    {
        private IProductsxCategoriesBW _productsxCategoriesBW;

        public ProductsCategoriesController(IProductsxCategoriesBW productsxCategoriesBW)
        {
            _productsxCategoriesBW = productsxCategoriesBW;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductsCategories productsCategories)
        {
            try
            {
                var result = await _productsxCategoriesBW.Add(productsCategories);
                return CreatedAtAction(nameof(Get), null);
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

        [HttpDelete("Eliminar/{IdProduct}, {IdCategory}")]
        public async Task<IActionResult> Delete([FromRoute] Guid IdProduct, int IdCategory)
        {
            try
            {
                var result = await _productsxCategoriesBW.Delete(IdProduct, IdCategory);
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _productsxCategoriesBW.Get();
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
    }
}
