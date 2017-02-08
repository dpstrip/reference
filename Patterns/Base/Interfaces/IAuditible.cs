using System;

namespace UMV.Reference.Patterns.Base.Interfaces
{
    public interface IAuditible
    {
        string CreateUser { get; set; }

        DateTime CreateDate { get; set; }

        string UpdateUser { get; set; }

        DateTime UpdateDate { get; set; }
    }
}