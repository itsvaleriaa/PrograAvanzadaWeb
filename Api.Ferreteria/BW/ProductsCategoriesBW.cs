using Abstractions.Interfaces.BW;
using Abstractions.Interfaces.DA;
using Abstractions.Models;

namespace BW
{
    public class ProductsCategoriesBW : IProductsxCategoriesBW
    {
        private IProductsCategoriesDA _productsCategoriesDA;

        public ProductsCategoriesBW(IProductsCategoriesDA productsCategoriesDA)
        {
            _productsCategoriesDA = productsCategoriesDA;
        }

        public async Task<Guid> Add(ProductsCategories productsCategories)
        {
            try
            {
                var result = await _productsCategoriesDA.Add(productsCategories);
                return result;
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                throw new ApplicationException("An error occurred trying to connect.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing your request.", ex);
            }
        }

        public async Task<Guid> Delete(Guid IdProduct, int IdCategory)
        {
            try
            {
                var result = await _productsCategoriesDA.Delete(IdProduct, IdCategory);
                return result;
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                throw new ApplicationException("An error occurred trying to connect.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing your request.", ex);
            }
        }

        public async Task<IEnumerable<ProductsCategories>> Get()
        {
            try
            {
                return await _productsCategoriesDA.Get();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                throw new ApplicationException("An error occurred trying to connect.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing your request.", ex);
            }
        }
    }
}
