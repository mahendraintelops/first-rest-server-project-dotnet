using MediatR;

namespace Application.Commands.AddressService
{
    public class UpdateAddressCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public string City { get; set; }
        
    
        
        public string Street { get; set; }
        
    
    }
}
