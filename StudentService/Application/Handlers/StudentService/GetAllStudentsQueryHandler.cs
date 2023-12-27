using AutoMapper;
using MediatR;
using Application.Queries.StudentService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.StudentService
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentResponse>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<List<StudentResponse>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var generatedStudent = await _studentRepository.GetAllAsync();
            var studentEntity = _mapper.Map<List<StudentResponse>>(generatedStudent);
            return studentEntity;
        }
    }
}
