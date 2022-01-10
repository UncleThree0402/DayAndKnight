using AnimatorScripts;
using Interfaces.CharacterBehaviour;

namespace StateMachine.CombatStateMachineScripts.State.SubState
{
    public class CombatCombo3State : CombatBaseState
    {
        public CombatCombo3State(CombatStateMachine combatStateMachine, CombatStateFactory factory) : base(
            combatStateMachine, factory)
        {
        }

        public override void StartState()
        {
            _combatStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsCombo3), true);
            _combatStateMachine.GetComponent<IStamina>().StaminaCost(30);
            _combatStateMachine.Combo3Time = 10;
            _combatStateMachine.IsAttacking = true;
            _combatStateMachine.CanMove.CanMove = false;
            _combatStateMachine.Weapon.CanHit = true;
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
            _combatStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsCombo3), false);
            _combatStateMachine.IsAttacking = false;
            _combatStateMachine.CanMove.CanMove = true;
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
                SwitchState(_factory.Wait());
            }
        }
    }
}