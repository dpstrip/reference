using UMV.Reference.Patterns.Models;

namespace UMV.Reference.Patterns.Repositories.Interfaces
{
    public interface IPipelineDefinitionRepository
    {
        PipelineDefinition Get(int id);

    }
}