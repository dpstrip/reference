using System;
using UMV.Reference.Patterns.Base.Enums;

namespace UMV.Reference.Patterns.Base.Interfaces
{
    public interface IAuditible : IIdentifiable
    {
        ObjectState ObjectState { get; set; }

        string CreateUser { get; set; }

        DateTime CreateDate { get; set; }

        string UpdateUser { get; set; }

        DateTime? UpdateDate { get; set; }
    }
}