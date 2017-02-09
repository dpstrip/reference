using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Base.Models;

namespace UMV.Reference.Patterns.Base
{
    public abstract class ChangeTrackable : Auditible, IChangeTrackable
    {
        private readonly List<PropertyInfo> _properties;
        private readonly List<PropertyInfo> _propertiesToIgnore;
        private readonly Dictionary<string, object> _originalValues = new Dictionary<string, object>();

        protected ChangeTrackable()
        {
            _propertiesToIgnore = typeof(Auditible).GetProperties().ToList();
            _properties = GetType().GetProperties().Where(x => !_propertiesToIgnore.Contains(x)).ToList();
        }

        public void InitializeChangeState()
        {
            // Save the current value of the properties to our dictionary.
            foreach (var property in _properties)
                _originalValues.Add(property.Name, property.GetValue(this));
        }

        public ChangeState GetChangeState()
        {
            // Filter properties by only getting what has changed
            var changedProperties = _properties.Where(p => !Equals(p.GetValue(this, null), _originalValues[p.Name])).ToArray();

            return new ChangeState
            {
                CreateDate = CreateDate,
                UpdateDate = UpdateDate,
                UpdateUser = UpdateUser,
                CreateUser = CreateUser,
                ChangedProperties = changedProperties.Select(x => new ChangedProperty
                {
                    Name = x.Name,
                    CurrentValue = x.GetValue(this),
                    OriginalValue = _originalValues[x.Name]
                })
            };
        }
    }
}