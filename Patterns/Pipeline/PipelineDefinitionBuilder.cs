using System.Linq;
using Ninject;
using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations.Interfaces;

namespace UMV.Reference.Patterns
{
    public class PipelineDefinitionBuilder
    {
        private readonly IKernel _kernel;

        public PipelineDefinitionBuilder(IKernel kernel)
        {
            _kernel = kernel;
        }

        public Pipeline<T> Build<T>(PipelineDefinition pipelineDefinition) where T : ITrackChanges
        {
            var pipleline = new Pipeline<T>();

            foreach (var operationName in pipelineDefinition.Operations.OrderBy(x => x.Order))
            {
                var operation = _kernel.Get<IOperation<T>>(operationName.Name);
                pipleline.Register(operation);
            }

            return pipleline;
        }
    }
}