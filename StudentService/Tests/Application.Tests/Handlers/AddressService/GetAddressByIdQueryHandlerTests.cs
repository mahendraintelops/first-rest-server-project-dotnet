using AutoMapper;
using Moq;
using Application.Handlers.AddressService;
using Application.Queries.AddressService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AddressService
{
    public class GetAddressByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsAddressResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new Address { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IAddressRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetAddressByIdQuery(Id);
            var handler = new GetAddressByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AddressResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
