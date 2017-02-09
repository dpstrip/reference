using UMV.Reference.Patterns.Base;

namespace UMV.Reference.Patterns.Models
{
    public class Member : ChangeTracker
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}