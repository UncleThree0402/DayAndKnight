using AnimatorScripts;
using UnityEngine;

namespace Weapons.Sword
{
    public class TwoSwordsBase : BaseWeapon
    {
        public override void SetWeaponTypeTrue(Animator animator)
        {
            animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsTwoWeapon),true);
        }

        public override void SetWeaponTypeFalse(Animator animator)
        {
            animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsTwoWeapon),false);
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
            return 5;
        }
    }
}