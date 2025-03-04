using Abstractions.Models;

namespace Abstractions.Interfaces.BW
{
    public interface ICartsxProductsBW
    {
        Task<IEnumerable<CartsxProducts>> Get();
        Task<CartsxProducts> Get(Guid Id);
        Task<Guid> Add(CartsxProducts cartsxProducts);
        Task<Guid> Update(CartsxProducts cartsxProducts);
        Task<Guid> Delete(Guid Id);
    }
}
