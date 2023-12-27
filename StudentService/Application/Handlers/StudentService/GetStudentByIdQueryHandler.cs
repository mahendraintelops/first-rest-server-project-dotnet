using AutoMapper;
using MediatR;
using Application.Queries.StudentService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.StudentService
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<StudentResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedStudent = await _studentRepository.GetByIdAsync(request.id);
            var studentEntity = _mapper.Map<StudentResponse>(generatedStudent);
            return studentEntity;
        }
    }
}
