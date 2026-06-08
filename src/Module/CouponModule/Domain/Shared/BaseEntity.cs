using System.Reflection.Metadata.Ecma335;

namespace CouponModule.Domain.Shared
{
    public class BaseEntity 
    {
        
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
