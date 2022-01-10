using AnimatorScripts;
using Stats;
using UnityEngine;

namespace Combat
{
    public class HitBoxController : MonoBehaviour
    {
        [SerializeField] private BasicStats _basicStats;
        [SerializeField] private Animator _animator;

        public void Determine(float value)
        {
            if (_animator.GetBool(AnimatorHash.GetHash(AnimationHash.IsBlock)) &&
                _basicStats.Stamina >= value) //Blocking
            {
                _basicStats.StaminaCost(value);
            }
            else //Hit
            {
                _basicStats.DoDamage(value);
            }
            
        }
    }
}