using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.StudentService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.StudentService
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStudentCommandHandler> _logger;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, ILogger<UpdateStudentCommandHandler> logger)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToUpdate = await _studentRepository.GetByIdAsync(request.Id);
            if (studentToUpdate == null)
            {
                throw new StudentNotFoundException(nameof(Student), request.Id);
            }

            _mapper.Map(request, studentToUpdate, typeof(UpdateStudentCommand), typeof(Student));
            await _studentRepository.UpdateAsync(studentToUpdate);
            _logger.LogInformation($"Student is successfully updated");
        }
    }
}
