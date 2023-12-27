using MediatR;
using Application.Responses;

namespace Application.Queries.StudentService
{
    public class GetStudentByIdQuery : IRequest<StudentResponse>
    {
        public int id { get; set; }

        public GetStudentByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
