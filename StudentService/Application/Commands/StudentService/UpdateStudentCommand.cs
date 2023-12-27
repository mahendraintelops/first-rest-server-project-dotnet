using MediatR;

namespace Application.Commands.StudentService
{
    public class UpdateStudentCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public string College { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public int RollNumber { get; set; }
        
    
    }
}
