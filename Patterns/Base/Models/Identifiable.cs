using UMV.Reference.Patterns.Base.Interfaces;

namespace UMV.Reference.Patterns.Base.Models
{
    public abstract class Identifiable : IIdentifiable
    {
        public int Id { get; set; }
    }
}