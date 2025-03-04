using Abstractions.Models;

namespace Abstractions.Interfaces.BW
{
    public interface ICartsBW
    {
        Task<IEnumerable<Carts>> Get();
        Task<Carts> Get(Guid Id);
        Task<Guid> Add(CartsRequest carts);
        Task<Guid> Update(Carts carts);
        Task<Guid> Delete(Guid Id);
    }
}
