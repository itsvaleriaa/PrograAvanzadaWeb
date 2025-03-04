using Abstractions.Interfaces.BC;
using Abstractions.Interfaces.BW;
using Abstractions.Interfaces.DA;
using Abstractions.Models;

namespace BW
{
    public class CategoriesBW : ICategoriesBW
    {
        private ICategoriesDA _categoriesDA;
        private IFormatTextBC<Categories> _formatText;
        private IFormatTextBC<CategoriesRequest> _formatTextRequest;

        public CategoriesBW(ICategoriesDA categoriesDA, IFormatTextBC<Categories> formatText, IFormatTextBC<CategoriesRequest> formatTextRequest)
        {
            _categoriesDA = categoriesDA;
            _formatText = formatText;
            _formatTextRequest = formatTextRequest;
        }

        public async Task<int> Add(CategoriesRequest categories)
        {
            try
            {
                categories = _formatTextRequest.FormatTextToUpper(categories);
                var result = await _categoriesDA.Add(categories);
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

        public async Task<int> Delete(int Id)
        {
            try
            {
                var result = await _categoriesDA.Delete(Id);
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

        public async Task<IEnumerable<Categories>> Get()
        {
            try
            {
                return await _categoriesDA.Get();
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

        public async Task<Categories> Get(int Id)
        {
            try
            {
                return await _categoriesDA.Get(Id);
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

        public async Task<int> Update(Categories categories)
        {
            try
            {
                categories = _formatText.FormatTextToUpper(categories);
                var result = await _categoriesDA.Update(categories);
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
