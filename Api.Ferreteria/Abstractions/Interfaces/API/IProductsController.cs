using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abstractions.Interfaces.API
{
    public interface IProductsController
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get([FromRoute] Guid Id);
        Task<IActionResult> Add([FromBody] ProductsRequest products);
        Task<IActionResult> Update([FromBody] Products products);
        Task<IActionResult> Delete([FromRoute] Guid Id);
    }
}
