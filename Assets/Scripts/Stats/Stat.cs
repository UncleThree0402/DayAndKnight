using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Stats
{
    [System.Serializable]
    public class Stat
    {
        public int baseValue;

        public Stat(int baseValue)
        {
            this.baseValue = baseValue;
        }

        public Stat() : this(0)
        {
            
        }

        private List<StatModifier> _modifiers = new List<StatModifier>();

        public int GetValue()
        {
            float finalValue = baseValue;
            foreach (var VARIABLE in _modifiers)
            {
                finalValue += VARIABLE.Value;
            }

            return (int)Math.Round(finalValue);
        }

        public void AddModifier(StatModifier modifier)
        {
            if (modifier !=null)
            {
                _modifiers.Add(modifier);
            }
        }

        public void RemoveModifier(StatModifier modifier)
        {
            if (modifier != null)
            {
                _modifiers.Remove(modifier);
            }
        }
    }
}