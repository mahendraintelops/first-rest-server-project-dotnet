using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AddressService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.AddressService
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAddressCommandHandler> _logger;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper, ILogger<UpdateAddressCommandHandler> logger)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var addressToUpdate = await _addressRepository.GetByIdAsync(request.Id);
            if (addressToUpdate == null)
            {
                throw new AddressNotFoundException(nameof(Address), request.Id);
            }

            _mapper.Map(request, addressToUpdate, typeof(UpdateAddressCommand), typeof(Address));
            await _addressRepository.UpdateAsync(addressToUpdate);
            _logger.LogInformation($"Address is successfully updated");
        }
    }
}
