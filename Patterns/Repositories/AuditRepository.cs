using System;
using UMV.Reference.Patterns.Base.Enums;
using UMV.Reference.Patterns.Base.Models;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        public void Save(ChangeState changeState)
        {
            var objectMessage = $"{changeState.CreateUser} Created on {changeState.CreateDate}";

            if (changeState.ObjectState == ObjectState.Changed)
                objectMessage = $"{objectMessage} and {changeState.UpdateUser} last updated on {changeState.UpdateDate} with the following changes";

            Console.WriteLine(objectMessage);
            foreach (var changedProperty in changeState.ChangedProperties)
            {
                Console.WriteLine($"\t{changedProperty.Name} : Change from {changedProperty.OriginalValue} to {changedProperty.CurrentValue}");
            }
        }
    }
}