using System;

namespace RTweak
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public abstract class TweakDigitAttribute : TweakAttribute
    {
        protected double _minValue;
        protected double _maxValue;

        public TweakDigitAttribute(double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public TweakDigitAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }
    }
}
