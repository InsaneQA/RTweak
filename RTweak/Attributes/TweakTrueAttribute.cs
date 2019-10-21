using System;
using System.Reflection;

namespace RTweak
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TweakTrueAttribute : TweakAttribute
    {
        private double _chance;

        public TweakTrueAttribute(double chance)
        {
            _chance = chance;
        }

        public TweakTrueAttribute()
        {
            _chance = 0.5f;
        }

        public override void SetValueForField(FieldInfo field, object obj, Random random)
        {
            if (TypeHelper.IsBoolType(field.FieldType))
            {
                throw new CustomAttributeFormatException();
            }

            field.SetValue(obj, random.GetBoolWithChance(_chance));
        }

        public override void SetValueForProperty(PropertyInfo property, object obj, Random random)
        {
            if (TypeHelper.IsBoolType(property.PropertyType))
            {
                throw new CustomAttributeFormatException();
            }

            property.SetValue(obj, random.GetBoolWithChance(_chance));
        }
    }
}
