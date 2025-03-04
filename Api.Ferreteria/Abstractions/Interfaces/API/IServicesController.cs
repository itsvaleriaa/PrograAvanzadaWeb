using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abstractions.Interfaces.API
{
    public interface IServicesController
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get([FromRoute] int Id);
        Task<IActionResult> Add([FromBody] ServicesRequest services);
        Task<IActionResult> Update([FromBody] Services services);
        Task<IActionResult> Delete([FromRoute] int Id);
    }
}
