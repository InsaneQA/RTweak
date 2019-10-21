using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RTweak
{
    public class TweakInjector
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inject(object obj, Action cleanUpMethod = null)
        {
            cleanUpMethod?.Invoke();
            InjectFields(obj);
            InjectProperties(obj);

        }

        private static void InjectFields(object obj)
        {
            foreach (var field in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (field.FieldType.Equals(typeof(bool)))
                {
                    FieldInjector.InjectBool(field, obj);
                    continue;
                }

                FieldInjector.InjectDigit(field, obj);
            }
        }

        private static void InjectProperties(object obj)
        {
            foreach (var property in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (property.PropertyType.Equals(typeof(bool)))
                {
                    PropertyInjector.InjectBool(property, obj);
                    continue;
                }

                PropertyInjector.InjectDigit(property, obj);
            }
        }
    }
}
