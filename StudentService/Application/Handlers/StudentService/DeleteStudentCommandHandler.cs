using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.StudentService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.StudentService
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<DeleteStudentCommandHandler> _logger;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository, ILogger<DeleteStudentCommandHandler> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToDelete = await _studentRepository.GetByIdAsync(request.Id);
            if (studentToDelete == null)
            {
                throw new StudentNotFoundException(nameof(Student), request.Id);
            }

            await _studentRepository.DeleteAsync(studentToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
