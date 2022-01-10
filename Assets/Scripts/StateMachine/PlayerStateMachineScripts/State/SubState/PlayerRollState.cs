using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AnimatorScripts;
using Interfaces.CharacterBehaviour;
using PlayerController;
using UnityEngine;

namespace PlayerController
{
    public class PlayerRollState : PlayerBaseState
    {
        private float m_targetAngle;

        private float m_Count = 0.0f;
        
        public PlayerRollState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(
            playerStateMachine, builder)
        {
        }

        public override void StartState()
        {

            //Stamina
            _playerStateMachine.gameObject.GetComponent<IStamina>().StaminaCost(30);

            m_Count = 0.0f;
            
            //Target Angle
            m_targetAngle = Mathf.Atan2(_playerStateMachine.DirectionInput.x,
                                _playerStateMachine.DirectionInput.y) * Mathf.Rad2Deg +
                            _playerStateMachine.CameraTransform.eulerAngles.y;

            // Resize
            _playerStateMachine.CharacterActor.SetBodySize(new Vector2(_playerStateMachine.CharacterActor.DefaultBodySize.x,
                _playerStateMachine.CharacterActor.DefaultBodySize.y / 1.4f));
            
            //Update Speed
            _playerStateMachine.RotateSpeed = 100.0f;
            
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsRoll), true);
        }

        public override void UpdateState()
        {
            m_Count += Time.deltaTime;
            _playerStateMachine.RotationQuaternion = Quaternion.Euler(0, m_targetAngle, 0);
            CheckSwitchState();
        }

        public override void EndState()
        {
            _playerStateMachine.RotateSpeed = 5.0f;
            _playerStateMachine.CharacterActor.SetBodySize(_playerStateMachine.CharacterActor.DefaultBodySize);
            _playerStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsRoll), false);
        }

        public override void InitSubSet()
        {
        }

        public override void CheckSwitchState()
        {
            if (m_Count >= 0.8f)
            {
                if (_playerStateMachine.IsWalkPress && _playerStateMachine.IsRunPress)
                {
                    SwitchState(_factory.Run());
                }
                else if (_playerStateMachine.IsWalkPress)
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