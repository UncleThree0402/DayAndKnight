using TMPro;
using UnityEngine;

namespace StateMachine.CombatStateMachineScripts.State.SubState
{
    public class CombatWaitState : CombatBaseState
    {
        public CombatWaitState(CombatStateMachine combatStateMachine, CombatStateFactory factory) : base(
            combatStateMachine, factory)
        {
        }

        public override void StartState()
        {
        }

        public override void UpdateState()
        {
            _combatStateMachine.Weapon.CanHit = false;
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
            if (_combatStateMachine.Animator.GetCurrentAnimatorStateInfo(2)
                .IsName(_combatStateMachine.Weapon.CombatModeString))
            {
                if (_combatStateMachine.IsAttack && _combatStateMachine.Stamina >= 10)
                {
                    SwitchState(_factory.Attack());
                }
                else if (_combatStateMachine.IsBlock)
                {
                    SwitchState(_factory.Block());
                }
                else if (_combatStateMachine.IsCombo1 && _combatStateMachine.Stamina >= 50 &&
                         _combatStateMachine.Combo1Time == 0)
                {
                    SwitchState(_factory.Combo1());
                }
                else if (_combatStateMachine.IsCombo2 && _combatStateMachine.Stamina >= 30 &&
                         _combatStateMachine.Combo2Time == 0)
                {
                    SwitchState(_factory.Combo2());
                }
                else if (_combatStateMachine.IsCombo3 && _combatStateMachine.Stamina >= 30 &&
                         _combatStateMachine.Combo3Time == 0)
                {
                    SwitchState(_factory.Combo3());
                }
                else if (_combatStateMachine.IsCombo4 && _combatStateMachine.Stamina >= 20 &&
                         _combatStateMachine.Combo4Time == 0)
                {
                    SwitchState(_factory.Combo4());
                }
            }
        }
    }
}