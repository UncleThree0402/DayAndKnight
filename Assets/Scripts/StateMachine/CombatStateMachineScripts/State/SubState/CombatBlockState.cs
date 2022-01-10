using AnimatorScripts;
using Interfaces.CharacterBehaviour;

namespace StateMachine.CombatStateMachineScripts.State.SubState
{
    public class CombatBlockState : CombatBaseState
    {
        public CombatBlockState(CombatStateMachine combatStateMachine, CombatStateFactory factory) : base(
            combatStateMachine, factory)
        {
        }

        public override void StartState()
        {
            _combatStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsBlock), true);
            _combatStateMachine.IsAttacking = true;
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
            _combatStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsBlock), false);
            _combatStateMachine.IsAttacking = false;
        }

        public override void InitSubSet()
        {
        }

        public override void CheckSwitchState()
        {
            if (!_combatStateMachine.IsBlock)
            {
                SwitchState(_factory.Wait());
            }
        }
    }
}