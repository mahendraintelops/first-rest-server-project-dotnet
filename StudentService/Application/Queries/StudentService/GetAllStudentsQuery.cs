using MediatR;
using Application.Responses;

namespace Application.Queries.StudentService
{
    public class GetAllStudentsQuery : IRequest<List<StudentResponse>>
    {

    }
}
