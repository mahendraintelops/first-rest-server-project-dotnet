using AutoMapper;
using Moq;
using Application.Handlers.AddressService;
using Application.Queries.AddressService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AddressService
{
    public class GetAllAddressesQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfAddressResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<Address> 
        {
            new Address { Id = 1 },
            new Address { Id = 2 }

        };

            var RepositoryMock = new Mock<IAddressRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllAddressesQuery();
            var handler = new GetAllAddressesQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<AddressResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
