using AnimatorScripts;
using UnityEngine;

namespace Weapons.Sword
{
    public class SpearSwordBase : BaseWeapon
    {
        
        protected SpearSwordBase()
        {
            _combatModeString = "SpearCombat";
        }
        
        public override void SetWeaponTypeTrue(Animator animator)
        {
            animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsSpear),true);
        }

        public override void SetWeaponTypeFalse(Animator animator)
        {
            animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsSpear),false);
        }

        public override int Combo1Tran()
        {
            return 2;
        }

        public override int Combo2Tran()
        {
            return 3;
        }

        public override int Combo3Tran()
        {
            return 2;
        }

        public override int Combo4Tran()
        {
            return 2;
        }

        public override int BasicAttackTran()
        {
            return 4;
        }
    }
}