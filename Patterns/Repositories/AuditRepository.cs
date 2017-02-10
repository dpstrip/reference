using System;
using System.Collections.Generic;
using UMV.Reference.Patterns.Base.Enums;
using UMV.Reference.Patterns.Base.Models;
using UMV.Reference.Patterns.Models;
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

    public class PipelineDefinitionRepository : IPipelineDefinitionRepository
    {
        public PipelineDefinition Get(int id)
        {
            return new PipelineDefinition
            {
                Operations = new List<OperationDefinition>
                {
                    new OperationDefinition {Order = 1, Name = "GetMemberFromRepositoryById"} ,
                    new OperationDefinition {Order = 2, Name = "InitializeChangeTracking"} ,
                    new OperationDefinition {Order = 3, Name = "AddAuditInformation"} ,
                    new OperationDefinition {Order = 4, Name = "UpdateMemberFromMessageOperation"} ,
                    new OperationDefinition {Order = 5, Name = "MemberChangeTracker"}
                }
            };
        }
    }
}