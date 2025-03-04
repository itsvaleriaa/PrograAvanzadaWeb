using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abstractions.Interfaces.API
{
    public interface ICartsController
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get([FromRoute] Guid Id);
        Task<IActionResult> Add([FromBody] CartsRequest carts);
        Task<IActionResult> Update([FromBody] Carts carts);
        Task<IActionResult> Delete([FromRoute] Guid Id);
    }
}
