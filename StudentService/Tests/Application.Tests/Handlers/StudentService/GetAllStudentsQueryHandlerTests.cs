using AutoMapper;
using Moq;
using Application.Handlers.StudentService;
using Application.Queries.StudentService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.StudentService
{
    public class GetAllStudentsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfStudentResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<Student> 
        {
            new Student { Id = 1 },
            new Student { Id = 2 }

        };

            var RepositoryMock = new Mock<IStudentRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllStudentsQuery();
            var handler = new GetAllStudentsQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<StudentResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
