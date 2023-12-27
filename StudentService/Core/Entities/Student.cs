using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Student : EntityBase
    {
        public int Id  { get; set; }
    
        
        public string College { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public int RollNumber { get; set; }
        
    
    }
}
