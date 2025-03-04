namespace Abstractions.Interfaces
{
    internal interface IModelsGeneric
    {
    }
    public interface IHasName
    {
        string Name { get; set; }
    }

    public interface IHasFirstLastName
    {
        string FirstLastName { get; set; }
    }

    public interface IHasCity
    {
        string City { get; set; }
    }

    public interface IHasAddress
    {
        string Address { get; set; }
    }

    public interface IHasEmail
    {
        string Email { get; set; }
    }
}