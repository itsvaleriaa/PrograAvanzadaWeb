namespace Abstractions.Interfaces.BC
{
    public interface IFormatTextBC<T> where T : IHasName
    {
        T FormatTextToUpper(T items);
    }
}
