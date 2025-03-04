using Abstractions.Interfaces.BC;
using Abstractions.Interfaces.BW;
using Abstractions.Interfaces.DA;
using Abstractions.Models;

namespace BW
{
    public class SuppliersBW : ISuppliersBW
    {
        private ISuppliersDA _suppliersDA;
        private IFormatTextBC<Suppliers> _formatText;
        private IFormatTextBC<SuppliersRequest> _formatTextRequest;

        public SuppliersBW(ISuppliersDA suppliersDA, IFormatTextBC<Suppliers> formatText, IFormatTextBC<SuppliersRequest> formatTextRequest)
        {
            _suppliersDA = suppliersDA;
            _formatText = formatText;
            _formatTextRequest = formatTextRequest;
        }

        public async Task<Guid> Add(SuppliersRequest suppliers)
        {
            try
            {
                suppliers = _formatTextRequest.FormatTextToUpper(suppliers);
                var result = await _suppliersDA.Add(suppliers);
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
                var result = await _suppliersDA.Delete(Id);
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

        public async Task<IEnumerable<Suppliers>> Get()
        {
            try
            {
                return await _suppliersDA.Get();
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

        public async Task<Suppliers> Get(Guid Id)
        {
            try
            {
                return await _suppliersDA.Get(Id);
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

        public async Task<Guid> Update(Suppliers suppliers)
        {
            try
            {
                suppliers = _formatText.FormatTextToUpper(suppliers);
                var result = await _suppliersDA.Update(suppliers);
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
