using Stats;

namespace Interfaces.CharacterBehaviour
{
    public interface IHealth
    {
        public void HealthGen(float value);

        public void DoDamage(float value);
    }
}