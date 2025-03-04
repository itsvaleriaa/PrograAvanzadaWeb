using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abstractions.Interfaces.API
{
    public interface ICartsxProductsController
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get([FromRoute] Guid Id);
        Task<IActionResult> Add([FromBody] CartsxProducts cartsxProducts);
        Task<IActionResult> Update([FromBody] CartsxProducts cartsxProducts);
        Task<IActionResult> Delete([FromRoute] Guid Id);
    }
}
