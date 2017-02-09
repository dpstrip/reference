using System;
using System.Threading;
using UMV.Reference.Patterns.Base.Enums;
using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Operations.Interfaces;

namespace UMV.Reference.Patterns.Operations
{
    public class AddAuditInformation : IOperation<IAuditible>
    {
        public IAuditible Execute(IAuditible auditible)
        {
            if (auditible.Id == 0)
            {
                auditible.ObjectState = ObjectState.New;

                auditible.UpdateDate = DateTime.UtcNow;
                auditible.UpdateUser = Thread.CurrentPrincipal.Identity.Name;
            }
            else
            {
                auditible.UpdateDate = DateTime.UtcNow;
                auditible.UpdateUser = Thread.CurrentPrincipal.Identity.Name;
            }

            return auditible;
        }
    }
}