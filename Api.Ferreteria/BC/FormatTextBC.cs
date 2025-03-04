using Abstractions.Interfaces;
using Abstractions.Interfaces.BC;

namespace BC
{
    public class FormatTextBC<T> : IFormatTextBC<T> where T : IHasName
    {
        public T FormatTextToUpper(T items)
        {
            if (items is IHasName nameItem)
            {
                nameItem.Name = items.Name.ToUpper();
            }
            if (items is IHasFirstLastName firstLastNameItem)
            {
                firstLastNameItem.FirstLastName = firstLastNameItem.FirstLastName.ToUpper();
            }

            if (items is IHasCity cityItem)
            {
                cityItem.City = cityItem.City.ToUpper();
            }

            if (items is IHasAddress addressItem)
            {
                addressItem.Address = addressItem.Address.ToUpper();
            }

            if (items is IHasEmail emailItem)
            {
                emailItem.Email = emailItem.Email.ToUpper();
            }
            return items;
        }
    }
}
