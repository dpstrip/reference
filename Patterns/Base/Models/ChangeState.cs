using System;
using System.Collections.Generic;
using UMV.Reference.Patterns.Base.Enums;
using UMV.Reference.Patterns.Base.Interfaces;

namespace UMV.Reference.Patterns.Base.Models
{
    public class ChangeState : IAuditible
    {
        public int Id { get; set; }

        public string CreateUser { get; set; }

        public DateTime CreateDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public ObjectState ObjectState { get; set; }

        public IEnumerable<ChangedProperty> ChangedProperties { get; set; }

    }
}