using AnimatorScripts;
using UnityEngine;

namespace Weapons.Sword
{
    public class OneHandSwordBase : BaseWeapon
    {
        protected OneHandSwordBase()
        {
            _combatModeString = "1HCombat";
        }
        public override void SetWeaponTypeTrue(Animator animator)
        {
            animator.SetBool(AnimatorHash.GetHash(AnimationHash.Is1H),true);
        }

        public override void SetWeaponTypeFalse(Animator animator)
        {
            animator.SetBool(AnimatorHash.GetHash(AnimationHash.Is1H),false);
        }

        public override int Combo1Tran()
        {
            return 2;
        }

        public override int Combo2Tran()
        {
            return 2;
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