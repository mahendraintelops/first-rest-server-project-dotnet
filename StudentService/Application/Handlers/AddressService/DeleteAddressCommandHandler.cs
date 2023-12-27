using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AddressService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.AddressService
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<DeleteAddressCommandHandler> _logger;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository, ILogger<DeleteAddressCommandHandler> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var addressToDelete = await _addressRepository.GetByIdAsync(request.Id);
            if (addressToDelete == null)
            {
                throw new AddressNotFoundException(nameof(Address), request.Id);
            }

            await _addressRepository.DeleteAsync(addressToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
