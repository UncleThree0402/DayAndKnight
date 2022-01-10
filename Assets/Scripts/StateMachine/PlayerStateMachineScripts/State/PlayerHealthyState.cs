using AnimatorScripts;

namespace PlayerController
{
    public class PlayerHealthyState : PlayerBaseState
    {
        public PlayerHealthyState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(playerStateMachine, builder)
        {
            _isRoot = true;
        }

        public override void StartState()
        {
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsHealthy), true);
            InitSubSet();
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsHealthy), false);
        }

        public override void InitSubSet()
        {
            SetSubState(_factory.Idle());
        }

        public override void CheckSwitchState()
        {
            if (_playerStateMachine.TargetCollider.Targets.Count > 0)
            {
                SwitchState(_factory.Combat());
            }
            else if (_playerStateMachine.Health <= 0)
            {
                SwitchState(_factory.Die());
            }
        }
    }
}