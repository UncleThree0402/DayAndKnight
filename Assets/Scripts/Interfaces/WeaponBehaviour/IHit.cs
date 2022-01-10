using Interfaces.CharacterBehaviour;

namespace Interfaces.WeaponBehaviour
{
    public interface IHit
    {
        public void Hit(IHitBox target ,int value);
    }
}