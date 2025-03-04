using Abstractions.Interfaces.BC;
using Abstractions.Interfaces.BW;
using Abstractions.Interfaces.DA;
using Abstractions.Models;

namespace BW
{
    public class PeopleBW : IPeopleBW
    {
        private IPeopleDA _peopleDA;
        private IFormatTextBC<People> _formatText;
        private IFormatTextBC<PeopleRequest> _formatTextRequest;

        public PeopleBW(IPeopleDA peopleDA, IFormatTextBC<People> formatText, IFormatTextBC<PeopleRequest> formatTextRequest)
        {
            _peopleDA = peopleDA;
            _formatText = formatText;
            _formatTextRequest = formatTextRequest;
        }

        public async Task<int> Add(PeopleRequest people)
        {
            try
            {
                people = _formatTextRequest.FormatTextToUpper(people);
                var result = await _peopleDA.Add(people);
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
                var result = await _peopleDA.Delete(Id);
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

        public async Task<IEnumerable<People>> Get()
        {
            try
            {
                return await _peopleDA.Get();
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

        public async Task<People> Get(int Id)
        {
            try
            {
                return await _peopleDA.Get(Id);
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

        public async Task<int> Update(People people)
        {
            try
            {
                people = _formatText.FormatTextToUpper(people);
                var result = await _peopleDA.Update(people);
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
