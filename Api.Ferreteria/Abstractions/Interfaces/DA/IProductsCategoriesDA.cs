using Abstractions.Models;

namespace Abstractions.Interfaces.DA
{
    public interface IProductsCategoriesDA
    {
        Task<IEnumerable<ProductsCategories>> Get();
        Task<Guid> Add(ProductsCategories productsCategories);
        Task<Guid> Delete(Guid IdProduct, int IdCategory);
    }
}
