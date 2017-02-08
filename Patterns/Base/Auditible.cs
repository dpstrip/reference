using System;
using UMV.Reference.Patterns.Base.Interfaces;

namespace UMV.Reference.Patterns.Base
{
    public abstract class Auditible : IAuditible
    {
        public string CreateUser { get; set; }

        public DateTime CreateDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}