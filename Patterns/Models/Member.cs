using System.Collections.Generic;
using UMV.Reference.Patterns.Base;

namespace UMV.Reference.Patterns.Models
{
    public class Member : TrackChanges
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Address> Addresses { get; set; }
    }
}