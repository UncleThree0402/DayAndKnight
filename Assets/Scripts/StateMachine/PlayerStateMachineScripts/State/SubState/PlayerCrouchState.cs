using AnimatorScripts;
using UnityEngine;

namespace PlayerController
{
    public class PlayerCrouchState : PlayerBaseState
    {
        public PlayerCrouchState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(
            playerStateMachine, builder)
        {
            
        }

        public override void StartState()
        {
            _playerStateMachine.CharacterActor.SetBodySize(new Vector2(_playerStateMachine.CharacterActor.DefaultBodySize.x,
                _playerStateMachine.CharacterActor.DefaultBodySize.y / 1.4f));
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsCrouch), true);
        }

        public override void UpdateState()
        {
            float targetAngle = Mathf.Atan2(_playerStateMachine.MoveCurrent.x, _playerStateMachine.MoveCurrent.y) * Mathf.Rad2Deg + _playerStateMachine.CameraTransform.eulerAngles.y;
            Vector3 vector3 = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _playerStateMachine.MoveVelocity = vector3 * _playerStateMachine.Speed * _playerStateMachine.UnderSlope(_playerStateMachine.CharacterActor);

            if (_playerStateMachine.Speed > 0.5f)
            {
                _playerStateMachine.RotationQuaternion = Quaternion.Euler(0, _playerStateMachine.CameraTransform.eulerAngles.y, 0);
            }
            
            if (_playerStateMachine.DirectionInput.x == 0.0f && _playerStateMachine.DirectionInput.y == 0.0f)
            {
                _playerStateMachine.TargetSpeed = 0.0f;
            }
            else
            {
                _playerStateMachine.TargetSpeed = 5.0f;
            }

            CheckSwitchState();
        }

        public override void EndState()
        {
            _playerStateMachine.CharacterActor.SetBodySize(_playerStateMachine.CharacterActor.DefaultBodySize);
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsCrouch), false);
        }

        public override void InitSubSet()
        {
            
        }

        public override void CheckSwitchState()
        {
            if (!_playerStateMachine.IsCrouchPress)
            {
                if (_playerStateMachine.IsWalkPress && _playerStateMachine.IsRunPress)
                {
                    SwitchState(_factory.Run());
                }
                else if (_playerStateMachine.IsWalkPress && !_playerStateMachine)
                {
                    SwitchState(_factory.Walk());
                }
                else
                {
                    SwitchState(_factory.Idle());
                }
            }
            else if (_playerStateMachine.CharacterActor.Velocity.y < -5.0f && !_playerStateMachine.IsJumpPress)
            {
                SwitchState(_factory.Fall());
            }
            else if (_playerStateMachine.IsJumpPress && _playerStateMachine.CharacterActor.IsStable)
            {
                SwitchState(_factory.Jump());
            }
            else if (_playerStateMachine.IsRollPress && _playerStateMachine.Stamina >= 30)
            {
                SwitchState(_factory.Roll());
            }
        }
    }
}