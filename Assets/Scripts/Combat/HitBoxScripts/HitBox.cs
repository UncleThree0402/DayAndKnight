using Interfaces.WeaponBehaviour;
using Stats;
using UnityEngine;

namespace Combat
{
    public enum HitBoxType
    {
        Head,
        Body,
        Hand,
        Leg
    }

    public enum TeamTag
    {
        Allies,
        Player,
        Enemy
    }

    public class HitBox : MonoBehaviour ,IHitBox
    {
        [SerializeField] private HitBoxType _hitBoxType;
        [SerializeField] private TeamTag _target;
        [SerializeField] private HitBoxController _hitBoxController;

        public void TakeDamage(int damage)
        {
            float factor = 1;
            if (_hitBoxType == HitBoxType.Head)
            {
                factor = 1.1f;
            }else if (_hitBoxType == HitBoxType.Leg)
            {
                factor = 0.3f;
            }else if (_hitBoxType == HitBoxType.Hand)
            {
                factor = 0.2f;
            }else if (_hitBoxType == HitBoxType.Body)
            {
                factor = 0.5f;
            }
            _hitBoxController.Determine(damage * factor);
        }
    }
}