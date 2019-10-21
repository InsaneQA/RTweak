using System;
using System.Collections.Generic;
using System.Text;

namespace RTweak
{
    public static class TypeHelper
    {
        public static bool IsBoolType(Type type)
        {
            return type != typeof(bool);
        }
    }
}
