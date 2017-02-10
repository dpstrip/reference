using System;
using UMV.Reference.Patterns.Base.Enums;
using UMV.Reference.Patterns.Base.Interfaces;

namespace UMV.Reference.Patterns.Base.Models
{
    public abstract class Auditible : Identifiable, IAuditible
    {
        public string CreateUser { get; set; }

        public DateTime CreateDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}