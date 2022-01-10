using System;
using AnimatorScripts;
using Interfaces.CharacterBehaviour;
using Interfaces.WeaponBehaviour;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Weapons.WeaponBasetype
{
    public class TwoHandSwordBase : BaseWeapon 
    {
        protected TwoHandSwordBase()
        {
            _combatModeString = "2HCombat";
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

        public override void SetWeaponTypeTrue(Animator animator)
        {
            animator.SetBool(AnimatorHash.GetHash(AnimationHash.Is2H),true);
        }
        
        public override void SetWeaponTypeFalse(Animator animator)
        {
            animator.SetBool(AnimatorHash.GetHash(AnimationHash.Is2H),true);
        }

    }
}