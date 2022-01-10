using UnityEngine;

namespace Interfaces.WeaponBehaviour
{
    public interface IWeapon
    {
        public int Damage { get;}
        
        public float Range { get;}
        
        public bool CanHit { get; set; }

        public string CombatModeString { get; }
        
        public string TeamTag { get; set; }

        public void SetWeaponTypeTrue(Animator animator);

        public void SetWeaponTypeFalse(Animator animator);

        public int Combo1Tran();
        public int Combo2Tran();
        public int Combo3Tran();
        public int Combo4Tran();

        public int BasicAttackTran();
    }
}