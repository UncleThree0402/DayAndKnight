using System.Collections;
using System.Collections.Generic;
using Interfaces.Observer;
using Stats;
using UI;
using UnityEngine;

public class StaminaBar : Bar
{
    public override void UpdateData(IObservable observable)
    {
        if (observable is BasicStats playerStats)
        {
            _target = playerStats.Stamina / playerStats.MaxStamina.GetValue();
            _maxValue = playerStats.MaxStamina.GetValue();
            _genRate = playerStats.StaminaGenRate.GetValue();
        }
    }
}
