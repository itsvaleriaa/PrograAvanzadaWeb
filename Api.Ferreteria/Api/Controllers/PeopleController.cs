using Abstractions.Interfaces.API;
using Abstractions.Interfaces.BW;
using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase, IPeopleController
    {
        private IPeopleBW _peopleBW;

        public PeopleController(IPeopleBW peopleBW)
        {
            _peopleBW = peopleBW;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PeopleRequest people)
        {
            try
            {
                var result = await _peopleBW.Add(people);
                return CreatedAtAction(nameof(Get), null, null);
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
                var result = await _peopleBW.Delete(Id);
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _peopleBW.Get();
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
                var result = await _peopleBW.Get(Id);
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
        public async Task<IActionResult> Update([FromBody] People people)
        {
            try
            {
                var result = await _peopleBW.Update(people);
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
