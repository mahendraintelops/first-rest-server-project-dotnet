using MediatR;
using Application.Responses;

namespace Application.Queries.AddressService
{
    public class GetAddressByIdQuery : IRequest<AddressResponse>
    {
        public int id { get; set; }

        public GetAddressByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
