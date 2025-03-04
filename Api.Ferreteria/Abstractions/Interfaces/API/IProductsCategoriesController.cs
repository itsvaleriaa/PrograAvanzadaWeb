using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abstractions.Interfaces.API
{
    public interface IProductsCategoriesController
    {
        Task<IActionResult> Get();
        Task<IActionResult> Add([FromBody] ProductsCategories productsCategories);
        Task<IActionResult> Delete([FromRoute] Guid IdProduct, int IdCategory);
    }
}
