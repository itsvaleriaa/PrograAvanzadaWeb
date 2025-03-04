using Abstractions.Interfaces.API;
using Abstractions.Interfaces.BW;
using Abstractions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = "6")]
    [Authorize(Roles = "1")]
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase, ISuppliersController
    {
        private ISuppliersBW _suppliersBW;

        public SuppliersController(ISuppliersBW suppliersBW)
        {
            _suppliersBW = suppliersBW;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SuppliersRequest suppliers)
        {
            try
            {
                var result = await _suppliersBW.Add(suppliers);
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
                var result = await _suppliersBW.Delete(Id);
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
                var result = await _suppliersBW.Get();
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
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            try
            {
                var result = await _suppliersBW.Get(Id);
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
        public async Task<IActionResult> Update([FromBody] Suppliers suppliers)
        {
            try
            {
                var result = await _suppliersBW.Update(suppliers);
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