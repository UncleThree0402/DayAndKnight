namespace Stats
{
    public enum StatType
    {
        Flat,
        Percent
    }

    public class StatModifier
    {
        public readonly float Value;
        public readonly StatType StatType;

        public StatModifier(float value, StatType statType)
        {
            Value = value;
            StatType = statType;
        }
    }
}