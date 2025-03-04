using Abstractions.Models;

namespace Abstractions.Interfaces.DA
{
    public interface ICategoriesDA
    {
        Task<IEnumerable<Categories>> Get();
        Task<Categories> Get(int Id);
        Task<int> Add(CategoriesRequest categories);
        Task<int> Update(Categories categories);
        Task<int> Delete(int Id);
    }
}
