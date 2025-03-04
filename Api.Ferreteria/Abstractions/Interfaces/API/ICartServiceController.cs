using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abstractions.Interfaces.API
{
    public interface ICartServiceController
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get([FromRoute] Guid Id);
        Task<IActionResult> Add([FromBody] CartService cartService);
        Task<IActionResult> Update([FromBody] CartService cartService);
        Task<IActionResult> Delete([FromRoute] Guid Id);
    }
}
