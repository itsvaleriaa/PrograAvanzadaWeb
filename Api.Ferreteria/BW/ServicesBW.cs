using Abstractions.Interfaces.BC;
using Abstractions.Interfaces.BW;
using Abstractions.Interfaces.DA;
using Abstractions.Models;

namespace BW
{
    public class ServicesBW : IServicesBW
    {
        private IServicesDA _servicesDA;
        private IFormatTextBC<Services> _formatText;
        private IFormatTextBC<ServicesRequest> _formatTextRequest;

        public ServicesBW(IServicesDA servicesDA, IFormatTextBC<Services> formatText, IFormatTextBC<ServicesRequest> formatTextRequest)
        {
            _servicesDA = servicesDA;
            _formatText = formatText;
            _formatTextRequest = formatTextRequest;
        }

        public async Task<int> Add(ServicesRequest services)
        {
            try
            {
                services = _formatTextRequest.FormatTextToUpper(services);
                var result = await _servicesDA.Add(services);
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
                var result = await _servicesDA.Delete(Id);
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

        public async Task<IEnumerable<Services>> Get()
        {
            try
            {
                return await _servicesDA.Get();
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

        public async Task<Services> Get(int Id)
        {
            try
            {
                return await _servicesDA.Get(Id);
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

        public async Task<int> Update(Services services)
        {
            try
            {
                services = _formatText.FormatTextToUpper(services);
                var result = await _servicesDA.Update(services);
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
