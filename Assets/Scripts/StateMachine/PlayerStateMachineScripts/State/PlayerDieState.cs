using System.Numerics;
using AnimatorScripts;
using Stats;
using UI;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace PlayerController
{
    public class PlayerDieState : PlayerBaseState
    {
        public PlayerDieState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(playerStateMachine, builder)
        {
        }

        public override void StartState()
        {
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsDie), true);
            _playerStateMachine.MoveVelocity = Vector3.zero;
            _playerStateMachine.CharacterActor.IsKinematic = true;
            _playerStateMachine.GetComponent<BasicStats>().HealthGenRate.baseValue = 0;
            _playerStateMachine.GetComponent<BasicStats>().StaminaGenRate.baseValue = 0;
            GameObject.FindObjectOfType<UIController>().Die();
        }

        public override void UpdateState()
        {
        }

        public override void EndState()
        {
        }

        public override void InitSubSet()
        {
        }

        public override void CheckSwitchState()
        {
        }
    }
}