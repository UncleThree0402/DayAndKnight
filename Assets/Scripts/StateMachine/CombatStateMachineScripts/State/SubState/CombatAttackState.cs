using AnimatorScripts;
using Interfaces.CharacterBehaviour;
using UnityEngine;

namespace StateMachine.CombatStateMachineScripts.State.SubState
{
    public class CombatAttackState : CombatBaseState
    {
        public CombatAttackState(CombatStateMachine combatStateMachine, CombatStateFactory factory) : base(
            combatStateMachine, factory)
        {
        }

        public override void StartState()
        {
            Debug.Log("Combat Attack");
            _combatStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsAttack), true);
            _combatStateMachine.IsAttacking = true;
            _combatStateMachine.Weapon.CanHit = true;
        }

        public override void UpdateState()
        {
            
            CheckSwitchState();
        }

        public override void EndState()
        {
            _combatStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsAttack), false);
            _combatStateMachine.IsAttacking = false;
            _combatStateMachine.Weapon.CanHit = false;
        }

        public override void InitSubSet()
        {
        }

        public override void CheckSwitchState()
        {
            if (_combatStateMachine.Animator.GetCurrentAnimatorStateInfo(2)
                    .IsName(_combatStateMachine.Weapon.CombatModeString) &&
                !_combatStateMachine.Animator.IsInTransition(2))
            {
                _combatStateMachine.GetComponent<IStamina>().StaminaCost(10);
                SwitchState(_factory.Wait());
            }
            else if (!_combatStateMachine.IsAttack)
            {
                SwitchState(_factory.Wait());
            }
        }
    }
}