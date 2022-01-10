using AnimatorScripts;
using Combat;
using Interfaces.WeaponBehaviour;
using InventoryScripts;
using StateMachine.CombatStateMachineScripts;
using StateMachine.CombatStateMachineScripts.State;
using UnityEngine;

namespace PlayerController
{
    public class PlayerCombatState : PlayerBaseState
    {
        public PlayerCombatState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder) : base(playerStateMachine, builder)
        {
            _isRoot = true;
        }

        public override void StartState()
        {
            InitSubSet();
            _playerStateMachine.GetComponent<BodySlots>().Weapon.SetActive(true);
            _playerStateMachine.GetComponent<PlayerCombatController>().enabled = true;
            _playerStateMachine.GetComponent<CombatStateMachine>().enabled = true;
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
            _playerStateMachine.GetComponent<PlayerCombatController>().enabled = false;
            _playerStateMachine.GetComponent<CombatStateMachine>().enabled = false;
            _playerStateMachine.GetComponent<BodySlots>().Weapon.SetActive(false);
        }

        public override void InitSubSet()
        {
            SetSubState(_factory.Idle());
        }

        public override void CheckSwitchState()
        {
            if (_playerStateMachine.Health <= 0)
            {
                SwitchState(_factory.Die());
            }else if (_playerStateMachine.TargetCollider.Targets.Count == 0)
            {
                SwitchState(_factory.Healthy());
            }
        }
    }
}