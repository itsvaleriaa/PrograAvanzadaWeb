using Abstractions.Models;

namespace Abstractions.Interfaces.BW
{
    public interface ISuppliersBW
    {
        Task<IEnumerable<Suppliers>> Get();
        Task<Suppliers> Get(Guid Id);
        Task<Guid> Add(SuppliersRequest suppliers);
        Task<Guid> Update(Suppliers suppliers);
        Task<Guid> Delete(Guid Id);
    }
}
