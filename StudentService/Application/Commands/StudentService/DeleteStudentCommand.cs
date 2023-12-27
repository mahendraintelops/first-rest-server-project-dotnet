using MediatR;

namespace Application.Commands.StudentService
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
