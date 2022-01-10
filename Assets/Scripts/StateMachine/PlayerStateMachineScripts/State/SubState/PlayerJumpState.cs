using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AnimatorScripts;
using PlayerController;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{

    public PlayerJumpState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(playerStateMachine, builder)
    {
        
    }

    public override void StartState()
    {
        _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsJump),true);
        _playerStateMachine.CharacterActor.ForceNotGrounded();
        _playerStateMachine.CharacterActor.VerticalVelocity = _playerStateMachine.CharacterActor.Up * 5.0f;
        _playerStateMachine.TargetSpeed = _playerStateMachine.Speed/2;
    }

    public override void UpdateState()
    {
        _playerStateMachine.Animator.SetFloat(AnimatorHash.GetHash(AnimationHash.VelocityY), _playerStateMachine.CharacterActor.Velocity.y);
        CheckSwitchState();
    }

    public override void EndState()
    {
        _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsJump),false);
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
