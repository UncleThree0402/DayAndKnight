using System.Collections;
using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using PlayerController;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(playerStateMachine, builder)
    {
    }

    public override void StartState()
    {
        _playerStateMachine.TargetSpeed = _playerStateMachine.SpeedFactor * 2;
    }

    public override void UpdateState()
    {
        float targetAngle = Mathf.Atan2(_playerStateMachine.MoveCurrent.x, _playerStateMachine.MoveCurrent.y) * Mathf.Rad2Deg + _playerStateMachine.CameraTransform.eulerAngles.y;
        Vector3 vector3 = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        _playerStateMachine.MoveVelocity = vector3 * _playerStateMachine.Speed * _playerStateMachine.UnderSlope(_playerStateMachine.CharacterActor);
        _playerStateMachine.RotationQuaternion = Quaternion.Euler(0 , _playerStateMachine.CameraTransform.eulerAngles.y , 0);
        
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
        else if(_playerStateMachine.IsWalkPress && !_playerStateMachine.IsRunPress)
        {
            SwitchState(_factory.Walk());
        }
        else if(!_playerStateMachine.IsWalkPress)
        {
            SwitchState(_factory.Idle());
        }else if (_playerStateMachine.CharacterActor.Velocity.y < -5.0f && !_playerStateMachine.IsJumpPress)
        {
            SwitchState(_factory.Fall());
        }
    }
}
