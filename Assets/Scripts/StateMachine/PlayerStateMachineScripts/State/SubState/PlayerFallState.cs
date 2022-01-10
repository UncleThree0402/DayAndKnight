using AnimatorScripts;

namespace PlayerController
{
    public class PlayerFallState : PlayerBaseState
    {
        public PlayerFallState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(playerStateMachine, builder)
        {
        }

        public override void StartState()
        {
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsFall),true);
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsFall),false);
        }

        public override void InitSubSet()
        {
            
        }

        public override void CheckSwitchState()
        {
            if (_playerStateMachine.CharacterActor.IsGrounded)
            {
                if (_playerStateMachine.IsCrouchPress)
                {
                    SwitchState(_factory.Crouch());
                }
                else if(_playerStateMachine.IsWalkPress && _playerStateMachine.IsRunPress)
                {
                    SwitchState(_factory.Run());
                }
                else if(_playerStateMachine.IsWalkPress)
                {
                    SwitchState(_factory.Walk());
                }
                else
                {
                    SwitchState(_factory.Idle());
                }
            }
        }
    }
}