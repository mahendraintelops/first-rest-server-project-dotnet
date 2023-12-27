using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.StudentService;
using Application.Queries.StudentService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentServiceController> _logger;
        public StudentServiceController(IMediator mediator, ILogger<StudentServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateStudent")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllStudents")]
        [ProducesResponseType(typeof(IEnumerable<List<StudentResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<StudentResponse>>> GetAllStudents(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllStudentsQuery(), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType(typeof(StudentResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<StudentResponse>> GetStudentById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Student GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetStudentByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpPut(Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation("Student DELETE request received for ID {id}", id);
            var cmd = new DeleteStudentCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }
        
    }
}
