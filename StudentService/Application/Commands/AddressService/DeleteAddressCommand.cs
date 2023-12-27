using MediatR;

namespace Application.Commands.AddressService
{
    public class DeleteAddressCommand : IRequest
    {
        public int Id { get; set; }
    }
}
