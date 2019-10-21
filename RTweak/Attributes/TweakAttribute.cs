using System;
using System.Reflection;

namespace RTweak
{
    public abstract class TweakAttribute : Attribute
    {
        public abstract void SetValueForField(FieldInfo field, object obj, Random random);

        public abstract void SetValueForProperty(PropertyInfo property, object obj, Random random);
    }
}
