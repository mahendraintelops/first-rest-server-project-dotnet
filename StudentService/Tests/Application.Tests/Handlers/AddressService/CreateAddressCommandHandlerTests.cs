using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.AddressService;
using Application.Handlers.AddressService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AddressService
{
    public class CreateAddressCommandHandlerTests
    {
        private readonly Mock<IAddressRepository> _addressRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateAddressCommandHandler>> _logger;

        public CreateAddressCommandHandlerTests()
        {
            _addressRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateAddressCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<Address>(request))
                .Returns(new Address()); 

            _addressRepository
                .Setup(r => r.AddAsync(It.IsAny<Address>()))
                .ReturnsAsync(new Address { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateAddressCommandHandler>>();
            var handler = new CreateAddressCommandHandler(_addressRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
