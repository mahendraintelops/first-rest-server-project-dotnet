using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.StudentService;
using Application.Handlers.StudentService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.StudentService
{
    public class CreateStudentCommandHandlerTests
    {
        private readonly Mock<IStudentRepository> _studentRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateStudentCommandHandler>> _logger;

        public CreateStudentCommandHandlerTests()
        {
            _studentRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateStudentCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<Student>(request))
                .Returns(new Student()); 

            _studentRepository
                .Setup(r => r.AddAsync(It.IsAny<Student>()))
                .ReturnsAsync(new Student { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateStudentCommandHandler>>();
            var handler = new CreateStudentCommandHandler(_studentRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
