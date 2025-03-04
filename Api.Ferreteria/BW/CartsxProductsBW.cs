using Abstractions.Interfaces.BW;
using Abstractions.Interfaces.DA;
using Abstractions.Models;

namespace BW
{
    public class CartsxProductsBW : ICartsxProductsBW
    {
        private ICartsxProductsDA _cartsxProductsDA;

        public CartsxProductsBW(ICartsxProductsDA cartsxProductsDA)
        {
            _cartsxProductsDA = cartsxProductsDA;
        }

        public async Task<Guid> Add(CartsxProducts cartsxProducts)
        {
            try
            {
                var result = await _cartsxProductsDA.Add(cartsxProducts);
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
                var result = await _cartsxProductsDA.Delete(Id);
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

        public async Task<IEnumerable<CartsxProducts>> Get()
        {
            try
            {
                return await _cartsxProductsDA.Get();
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

        public async Task<CartsxProducts> Get(Guid Id)
        {
            try
            {
                return await _cartsxProductsDA.Get(Id);
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

        public async Task<Guid> Update(CartsxProducts cartsxProducts)
        {
            try
            {
                var result = await _cartsxProductsDA.Update(cartsxProducts);
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
