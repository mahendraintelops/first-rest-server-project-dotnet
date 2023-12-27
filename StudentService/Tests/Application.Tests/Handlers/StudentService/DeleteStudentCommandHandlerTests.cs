﻿using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.StudentService;
using Application.Exceptions;
using Application.Handlers.StudentService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.StudentService
{
    public class DeleteStudentCommandHandlerTests
    {
        private readonly Mock<IStudentRepository> _studentRepository;
        private readonly Mock<ILogger<DeleteStudentCommandHandler>> _logger;

        public DeleteStudentCommandHandlerTests()
        {
            _studentRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsStudentNotFoundExceptionWhenStudentNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteStudentCommand { Id = Id }; // Create a request object

            _studentRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Student)null); // Mock the repository to return null

            var handler = new DeleteStudentCommandHandler(_studentRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<StudentNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
