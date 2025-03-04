using Abstractions.Models;

namespace Abstractions.Interfaces.BW
{
    public interface ICartServiceBW
    {
        Task<IEnumerable<CartService>> Get();
        Task<CartService> Get(Guid Id);
        Task<Guid> Add(CartService cartService);
        Task<Guid> Update(CartService cartService);
        Task<Guid> Delete(Guid Id);
    }
}
