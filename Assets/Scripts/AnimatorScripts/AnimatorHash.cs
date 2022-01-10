using UnityEngine;

namespace AnimatorScripts
{
    public enum AnimationHash
    {
        IsJump,
        IsFall,
        IsRoll,
        IsCrouch,
        IsCombat,
        IsHealthy,
        IsAttack,
        IsBlock,
        IsCombo1,
        IsCombo2,
        IsCombo3,
        IsCombo4,
        IsDie,
        Is1H,
        Is2H,
        IsTwoWeapon,
        IsSpear,
        Velocity,
        VelocityX,
        VelocityY,
        VelocityZ
    }
    
    public static class AnimatorHash
    {
        
        //Return Animator Hash
        public static int GetHash(AnimationHash animationHash)
        {
            return Animator.StringToHash(animationHash.ToString());
        }
    }
}