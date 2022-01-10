using System.Collections;
using System.Collections.Generic;
using AnimatorScripts;
using PlayerController;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(playerStateMachine, builder)
    {
    }

    public override void StartState()
    {
        _playerStateMachine.TargetSpeed = 0.0f;
        _playerStateMachine.Animator.SetFloat(AnimatorHash.GetHash(AnimationHash.VelocityX), 0.0f);
        _playerStateMachine.Animator.SetFloat(AnimatorHash.GetHash(AnimationHash.VelocityZ), 0.0f);
    }

    public override void UpdateState()
    {
        float targetAngle =
            Mathf.Atan2(_playerStateMachine.MoveCurrent.x, _playerStateMachine.MoveCurrent.y) * Mathf.Rad2Deg +
            _playerStateMachine.CameraTransform.eulerAngles.y;
        Vector3 vector3 = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        _playerStateMachine.MoveVelocity = vector3 * _playerStateMachine.Speed * _playerStateMachine.UnderSlope(_playerStateMachine.CharacterActor);

        CheckSwitchState();
    }

    public override void EndState()
    {
        
    }
    
    public override void InitSubSet()
    {
        
    }

    public override void CheckSwitchState()
    {
        if (_playerStateMachine.IsJumpPress && _playerStateMachine.CharacterActor.IsStable)
        {
            SwitchState(_factory.Jump());
        }else if (_playerStateMachine.IsRollPress && _playerStateMachine.Stamina >= 30)
        {
            SwitchState(_factory.Roll());
        }else if (_playerStateMachine.IsCrouchPress)
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
        else if (_playerStateMachine.CharacterActor.Velocity.y < -5.0f && !_playerStateMachine.IsJumpPress)
        {
            SwitchState(_factory.Fall());
        }
    }
}
