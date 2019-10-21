using System;
using System.Reflection;

namespace RTweak
{
    public class PropertyInjector : BaseInjector
    {
        private static void InjectRange(PropertyInfo property, object obj)
        {
            var attribute = Attribute.GetCustomAttribute(property, typeof(TweakRangeAttribute), true) as TweakRangeAttribute;

            if (attribute == null)
            {
                return;
            }

            attribute.SetValueForProperty(property, obj, random);
        }

        public static void InjectDigit(PropertyInfo property, object obj)
        {
            InjectRange(property, obj);
        }

        public static void InjectBool(PropertyInfo property, object obj)
        {
            var attribute = Attribute.GetCustomAttribute(property, typeof(TweakTrueAttribute), true) as TweakTrueAttribute;

            if (attribute == null)
            {
                return;
            }

            attribute.SetValueForProperty(property, obj, random);
        }
    }
}
