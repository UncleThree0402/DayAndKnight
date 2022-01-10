using Interfaces.Observer;
using Stats;

namespace UI
{
    public class HealthBar : Bar
    {
        public override void UpdateData(IObservable observable)
        {
            if (observable is BasicStats basicStats)
            {
                _target = basicStats.Health/basicStats.MaxHealth.GetValue();
                _maxValue = basicStats.MaxHealth.GetValue();
                //_genRate = basicStats.HealthGenRate.GetValue() > 0 ? basicStats.HealthGenRate.GetValue() : 1;
            }
        }
    }
    
}