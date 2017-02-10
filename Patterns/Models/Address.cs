using UMV.Reference.Patterns.Base;

namespace UMV.Reference.Patterns.Models
{
    public class Address: TrackChanges
    {
        public string AddressLine1 { get; set; }

        public string City { get; set; }
    }
}