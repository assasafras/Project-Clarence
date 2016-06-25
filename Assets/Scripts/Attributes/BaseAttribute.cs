namespace Assets.Scripts.Attributes
{
    [System.Serializable]
    public class BaseAttribute
    {
        public float baseValue;
        public float baseMultiplier;

        public BaseAttribute() : this(1, 0) {}
        public BaseAttribute(float value) : this(value, 0) { }
        public BaseAttribute(float value, float multiplier)
        {
            baseValue = value;
            baseMultiplier = multiplier;
        }
    }
}
