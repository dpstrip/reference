using UMV.Reference.Patterns.Base;

namespace UMV.Reference.Patterns.Models
{
    public class Address: ChangeTracker
    {
        public string AddressLine1 { get; set; }

        public string City { get; set; }
    }
}