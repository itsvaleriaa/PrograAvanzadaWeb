using Abstractions.Models;

namespace Abstractions.Interfaces.DA
{
    public interface IProductsDA
    {
        Task<IEnumerable<Products>> Get();
        Task<Products> Get(Guid Id);
        Task<Guid> Add(ProductsRequest products);
        Task<Guid> Update(Products products);
        Task<Guid> Delete(Guid Id);
    }
}
