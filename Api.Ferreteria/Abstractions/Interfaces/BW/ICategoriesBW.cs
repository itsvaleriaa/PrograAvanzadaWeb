using Abstractions.Models;

namespace Abstractions.Interfaces.BW
{
    public interface ICategoriesBW
    {
        Task<IEnumerable<Categories>> Get();
        Task<Categories> Get(int Id);
        Task<int> Add(CategoriesRequest categories);
        Task<int> Update(Categories categories);
        Task<int> Delete(int Id);
    }
}
