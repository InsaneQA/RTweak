using System;
using System.Reflection;

namespace RTweak
{
    public class FieldInjector : BaseInjector
    {
        private static void InjectRange(FieldInfo field, object obj)
        {
            var attribute = Attribute.GetCustomAttribute(field, typeof(TweakRangeAttribute), true) as TweakRangeAttribute;

            if (attribute == null)
            {
                return;
            }

            attribute.SetValueForField(field, obj, random);
        }

        public static void InjectDigit(FieldInfo field, object obj)
        {
            InjectRange(field, obj);
        }

        public static void InjectBool(FieldInfo field, object obj)
        {
            var attribute = Attribute.GetCustomAttribute(field, typeof(TweakTrueAttribute), true) as TweakTrueAttribute;

            if (attribute == null)
            {
                return;
            }

            attribute.SetValueForField(field, obj, random);
        }
    }
}
