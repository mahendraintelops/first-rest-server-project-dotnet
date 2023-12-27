using AutoMapper;
using MediatR;
using Application.Queries.AddressService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.AddressService
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, List<AddressResponse>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public GetAllAddressesQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<List<AddressResponse>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var generatedAddress = await _addressRepository.GetAllAsync();
            var addressEntity = _mapper.Map<List<AddressResponse>>(generatedAddress);
            return addressEntity;
        }
    }
}
