using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AddressService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.AddressService
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAddressCommandHandler> _logger;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper, ILogger<CreateAddressCommandHandler> logger)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var addressEntity = _mapper.Map<Address>(request);

            /*****************************************************************************/
            var generatedAddress = await _addressRepository.AddAsync(addressEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedAddress} successfully created.");
            return generatedAddress.Id;
        }
    }
}
