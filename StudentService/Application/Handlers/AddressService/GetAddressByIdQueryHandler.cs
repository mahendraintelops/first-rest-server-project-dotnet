using AutoMapper;
using MediatR;
using Application.Queries.AddressService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.AddressService
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public GetAddressByIdQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<AddressResponse> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedAddress = await _addressRepository.GetByIdAsync(request.id);
            var addressEntity = _mapper.Map<AddressResponse>(generatedAddress);
            return addressEntity;
        }
    }
}
