using UMV.Reference.Patterns.Base;

namespace UMV.Reference.Patterns.Models
{
    public class Member : ChangeTracking
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}