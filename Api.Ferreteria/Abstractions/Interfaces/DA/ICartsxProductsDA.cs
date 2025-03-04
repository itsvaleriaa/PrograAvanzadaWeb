using Abstractions.Models;

namespace Abstractions.Interfaces.DA
{
    public interface ICartsxProductsDA
    {
        Task<IEnumerable<CartsxProducts>> Get();
        Task<CartsxProducts> Get(Guid Id);
        Task<Guid> Add(CartsxProducts cartsxProducts);
        Task<Guid> Update(CartsxProducts cartsxProducts);
        Task<Guid> Delete(Guid Id);
    }
}
