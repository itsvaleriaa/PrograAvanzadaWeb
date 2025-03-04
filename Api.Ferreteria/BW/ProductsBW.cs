using Abstractions.Interfaces.BC;
using Abstractions.Interfaces.BW;
using Abstractions.Interfaces.DA;
using Abstractions.Models;

namespace BW
{
    public class ProductsBW : IProductsBW
    {
        private IProductsDA _productsDA;
        private IFormatTextBC<Products> _formatText;
        private IFormatTextBC<ProductsRequest> _formatTextRequest;

        public ProductsBW(IProductsDA productsDA, IFormatTextBC<Products> formatText, IFormatTextBC<ProductsRequest> formatTextRequest)
        {
            _productsDA = productsDA;
            _formatText = formatText;
            _formatTextRequest = formatTextRequest;
        }

        public async Task<Guid> Add(ProductsRequest products)
        {
            try
            {
                products = _formatTextRequest.FormatTextToUpper(products);
                var result = await _productsDA.Add(products);
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

        public async Task<Guid> Delete(Guid Id)
        {
            try
            {
                var result = await _productsDA.Delete(Id);
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

        public async Task<IEnumerable<Products>> Get()
        {
            try
            {
                return await _productsDA.Get();
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

        public async Task<Products> Get(Guid Id)
        {
            try
            {
                return await _productsDA.Get(Id);
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

        public async Task<Guid> Update(Products products)
        {
            try
            {
                products = _formatText.FormatTextToUpper(products);
                var result = await _productsDA.Update(products);
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
    }
}
