using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.AddressService;
using Application.Exceptions;
using Application.Handlers.AddressService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AddressService
{
    public class UpdateAddressCommandHandlerTests
    {
        private readonly Mock<IAddressRepository> _addressRepository;
        private readonly Mock<ILogger<UpdateAddressCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateAddressCommandHandlerTests()
        {
            _addressRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsAddressNotFoundExceptionWhenAddressNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateAddressCommand { Id = Id }; // Create a request object

            _addressRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Address)null); // Mock the repository to return null

            var handler = new UpdateAddressCommandHandler(_addressRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<AddressNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
