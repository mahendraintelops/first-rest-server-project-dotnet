using MediatR;
using Application.Responses;

namespace Application.Queries.AddressService
{
    public class GetAllAddressesQuery : IRequest<List<AddressResponse>>
    {

    }
}
