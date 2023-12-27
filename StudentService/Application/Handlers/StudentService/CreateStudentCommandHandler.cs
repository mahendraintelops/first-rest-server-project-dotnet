using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.StudentService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.StudentService
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateStudentCommandHandler> _logger;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, ILogger<CreateStudentCommandHandler> logger)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Student>(request);

            /*****************************************************************************/
            var generatedStudent = await _studentRepository.AddAsync(studentEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedStudent} successfully created.");
            return generatedStudent.Id;
        }
    }
}
