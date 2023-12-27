using AutoMapper;
using Moq;
using Application.Handlers.StudentService;
using Application.Queries.StudentService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.StudentService
{
    public class GetStudentByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsStudentResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new Student { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IStudentRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetStudentByIdQuery(Id);
            var handler = new GetStudentByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<StudentResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
