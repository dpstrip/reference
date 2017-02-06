using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UMV.Reference.Patterns.Base
{
    public abstract class ChangeTracking : Auditible
    {
        private readonly List<PropertyInfo> _properties;
        private readonly Dictionary<string, object> _originalValues = new Dictionary<string, object>();

        protected ChangeTracking()
        {
            _properties = GetType().GetProperties().ToList();
        }

        public void Initialize()
        {
            // Save the current value of the properties to our dictionary.
            foreach (var property in _properties)
                _originalValues.Add(property.Name, property.GetValue(this));
        }

        public Dictionary<string, object> GetChanges()
        {
            // Filter properties by only getting what has changed
            var changedProperties = _properties.Where(p => !Equals(p.GetValue(this, null), _originalValues[p.Name])).ToArray();

            return changedProperties.ToDictionary(property => property.Name, property => property.GetValue(this));
        }
    }
}