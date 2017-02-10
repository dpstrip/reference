using System;
using System.Linq;
using System.Threading;
using UMV.Reference.Patterns.Base.Enums;
using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Operations.Interfaces;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Operations
{
    public class ChangeTracker<T> : IOperation<T> where T : IChangeTracker
    {
        private readonly IAuditRepository _auditRepository;

        public ChangeTracker(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public T Execute(T changeTrackable)
        {
            var changes = changeTrackable.GetChangeState();

            if (changes.ChangedProperties.Any())
            {
                changeTrackable.ObjectState = ObjectState.Changed;
                changeTrackable.UpdateDate = DateTime.UtcNow;
                changeTrackable.UpdateUser = Thread.CurrentPrincipal.Identity.Name;
            }
            else if (changeTrackable.ObjectState != ObjectState.New)
            {
                changeTrackable.ObjectState = ObjectState.NoChange;
            }

            _auditRepository.Save(changes);

            return changeTrackable;
        }
    }
}