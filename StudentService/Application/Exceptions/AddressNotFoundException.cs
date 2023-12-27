namespace Application.Exceptions
{
    public class AddressNotFoundException : ApplicationException
    {
        public AddressNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
