using Abstractions.Models;

namespace Abstractions.Interfaces.BW
{
    public interface IProductsxCategoriesBW
    {
        Task<IEnumerable<ProductsCategories>> Get();
        Task<Guid> Add(ProductsCategories productsCategories);
        Task<Guid> Delete(Guid IdProduct, int IdCategory);
    }
}
