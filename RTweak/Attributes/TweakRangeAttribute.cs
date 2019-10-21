using System;
using System.Reflection;

namespace RTweak
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TweakRangeAttribute : TweakDigitAttribute
    {
        public TweakRangeAttribute(double minValue, double maxValue) : base(minValue, maxValue) { }

        public override void SetValueForField(FieldInfo field, object obj, Random random)
        {
            switch (Type.GetTypeCode(field.FieldType))
            {
                case TypeCode.Byte:
                    _minValue = (_minValue > 0) ? _minValue : 0;
                    field.SetValue(obj, Convert.ToByte(GetRandomIntValue(random)));
                    break;
                case TypeCode.SByte:
                    field.SetValue(obj, Convert.ToSByte(GetRandomIntValue(random)));
                    break;
                case TypeCode.UInt16:
                    _minValue = (_minValue > 0) ? _minValue : 0;
                    field.SetValue(obj, Convert.ToUInt16(GetRandomIntValue(random)));
                    break;
                case TypeCode.UInt32:
                    _minValue = (_minValue > 0) ? _minValue : 0;
                    field.SetValue(obj, Convert.ToUInt32(GetRandomIntValue(random)));
                    break;
                case TypeCode.UInt64:
                    _minValue = (_minValue > 0) ? _minValue : 0;
                    field.SetValue(obj, Convert.ToUInt64(GetRandomIntValue(random)));
                    break;
                case TypeCode.Int16:
                    field.SetValue(obj, Convert.ToInt16(GetRandomIntValue(random)));
                    break;
                case TypeCode.Int32:
                    field.SetValue(obj, GetRandomIntValue(random));
                    break;
                case TypeCode.Int64:
                    field.SetValue(obj, Convert.ToInt64(GetRandomIntValue(random)));
                    break;
                case TypeCode.Double:
                    field.SetValue(obj, GetRandomDoubleValue(random));
                    break;
                case TypeCode.Single:
                    field.SetValue(obj, Convert.ToSingle(GetRandomDoubleValue(random)));
                    break;
                case TypeCode.Decimal:
                    field.SetValue(obj, Convert.ToDecimal(GetRandomDoubleValue(random)));
                    break;
                default:
                    throw new CustomAttributeFormatException();
            }
        }

        protected virtual double GetRandomDoubleValue(Random random)
        {
            return random.GetDoubleInRange(_minValue, _maxValue);
        }

        protected virtual int GetRandomIntValue(Random random)
        {
            return random.Next(Convert.ToInt32(Math.Round(_minValue, MidpointRounding.AwayFromZero)), Convert.ToInt32(Math.Round(_maxValue + 1, MidpointRounding.AwayFromZero)));
        }

        public override void SetValueForProperty(PropertyInfo property, object obj, Random random)
        {
            switch (Type.GetTypeCode(property.PropertyType))
            {
                case TypeCode.Byte:
                    _minValue = (_minValue > 0) ? _minValue : 0;
                    property.SetValue(obj, Convert.ToByte(GetRandomIntValue(random)));
                    break;
                case TypeCode.SByte:
                    property.SetValue(obj, Convert.ToSByte(GetRandomIntValue(random)));
                    break;
                case TypeCode.UInt16:
                    _minValue = (_minValue > 0) ? _minValue : 0;
                    property.SetValue(obj, Convert.ToUInt16(GetRandomIntValue(random)));
                    break;
                case TypeCode.UInt32:
                    _minValue = (_minValue > 0) ? _minValue : 0;
                    property.SetValue(obj, Convert.ToUInt32(GetRandomIntValue(random)));
                    break;
                case TypeCode.UInt64:
                    _minValue = (_minValue > 0) ? _minValue : 0;
                    property.SetValue(obj, Convert.ToUInt64(GetRandomIntValue(random)));
                    break;
                case TypeCode.Int16:
                    property.SetValue(obj, Convert.ToInt16(GetRandomIntValue(random)));
                    break;
                case TypeCode.Int32:
                    property.SetValue(obj, GetRandomIntValue(random));
                    break;
                case TypeCode.Int64:
                    property.SetValue(obj, Convert.ToInt64(GetRandomIntValue(random)));
                    break;
                case TypeCode.Double:
                    property.SetValue(obj, GetRandomDoubleValue(random));
                    break;
                case TypeCode.Single:
                    property.SetValue(obj, Convert.ToSingle(GetRandomDoubleValue(random)));
                    break;
                case TypeCode.Decimal:
                    property.SetValue(obj, Convert.ToDecimal(GetRandomDoubleValue(random)));
                    break;
                default:
                    throw new CustomAttributeFormatException();
            }
        }
    }
}
