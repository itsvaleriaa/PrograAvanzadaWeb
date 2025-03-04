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
    public class CategoriesController : ControllerBase, ICategoriesController
    {
        private ICategoriesBW _categoriesBW;

        public CategoriesController(ICategoriesBW categoriesBW)
        {
            _categoriesBW = categoriesBW;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoriesRequest categories)
        {
            try
            {
                var result = await _categoriesBW.Add(categories);
                //return CreatedAtAction(nameof(Get), new { Id = result }, null);
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
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            try
            {
                var result = await _categoriesBW.Delete(Id);
                if (result == 0)
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
                var result = await _categoriesBW.Get();
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

        [HttpGet("Obtener/{Id}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            try
            {
                var result = await _categoriesBW.Get(Id);
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
        public async Task<IActionResult> Update([FromBody] Categories categories)
        {
            try
            {
                var result = await _categoriesBW.Update(categories);
                if (result == 0)
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
