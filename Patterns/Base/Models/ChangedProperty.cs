namespace UMV.Reference.Patterns.Base.Models
{
    public class ChangedProperty
    {
        public string Name { get; set; }

        public object OriginalValue { get; set; }

        public object CurrentValue { get; set; }
    }
}