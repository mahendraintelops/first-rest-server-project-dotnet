using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Address : EntityBase
    {
        public int Id  { get; set; }
    
        
        public string City { get; set; }
        
    
        
        public string Street { get; set; }
        
    
    }
}
