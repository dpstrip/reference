using UMV.Reference.Patterns.Base.Models;

namespace UMV.Reference.Patterns.Models
{
    public class Message : Identifiable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AddressLine1 { get; set; }

        public string City { get; set; }
    }
}