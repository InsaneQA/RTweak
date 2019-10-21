using System;
using System.Reflection;

namespace RTweak
{
    public class TweakDeviateAttribute : TweakRangeAttribute
    {
        private double _deviationPercentUp;
        private double _deviationPercentDown;

        public TweakDeviateAttribute(double deviationPercent) : base(0, 0)
        {
            _deviationPercentUp = deviationPercent;
            _deviationPercentDown = _deviationPercentUp;
        }

        public TweakDeviateAttribute(double deviationPercentDown, double deviationPercentUp) : base(0, 0)
        {
            _deviationPercentUp = deviationPercentUp;
            _deviationPercentDown = deviationPercentDown;
        }

        public override void SetValueForField(FieldInfo field, object obj, Random random)
        {
            var value = Convert.ToDouble(field.GetValue(obj));
            UpdateMinAndMaxValues(value);
            base.SetValueForField(field, obj, random);
        }

        public override void SetValueForProperty(PropertyInfo property, object obj, Random random)
        {
            var value = Convert.ToDouble(property.GetValue(obj));
            UpdateMinAndMaxValues(value);
            base.SetValueForProperty(property, obj, random);
        }

        private void UpdateMinAndMaxValues(double value)
        {
            _minValue = (value > 0) ? value * (1 - _deviationPercentDown / 100d) : value * (1 + _deviationPercentDown / 100d);
            _maxValue = (value > 0) ? value * (1 + _deviationPercentUp / 100d) : value * (1 - _deviationPercentUp / 100d);
        }
    }
}
