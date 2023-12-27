using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.AddressService;
using Application.Queries.AddressService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AddressServiceController> _logger;
        public AddressServiceController(IMediator mediator, ILogger<AddressServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAddress([FromBody] CreateAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllAddresses")]
        [ProducesResponseType(typeof(IEnumerable<List<AddressResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AddressResponse>>> GetAllAddresses(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllAddressesQuery(), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpGet("{id}", Name = "GetAddressById")]
        [ProducesResponseType(typeof(AddressResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AddressResponse>> GetAddressById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Address GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetAddressByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpPut(Name = "UpdateAddress")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAddress([FromBody] UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
        [HttpDelete("{id}", Name = "DeleteAddress")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            _logger.LogInformation("Address DELETE request received for ID {id}", id);
            var cmd = new DeleteAddressCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }
        
    }
}
