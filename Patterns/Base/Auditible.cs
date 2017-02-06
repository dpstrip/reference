using System;

namespace UMV.Reference.Patterns.Base
{
    public abstract class Auditible
    {
        public string CreateUser { get; set; }

        public DateTime CreateDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}