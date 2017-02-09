using UMV.Reference.Patterns.Base;

namespace UMV.Reference.Patterns.Models
{
    public class Address: ChangeTrackable
    {
        public string AddressLine1 { get; set; }

        public string City { get; set; }
    }
}