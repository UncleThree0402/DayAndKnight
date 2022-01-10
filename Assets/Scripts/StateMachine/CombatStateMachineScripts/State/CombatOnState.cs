using AnimatorScripts;

namespace StateMachine.CombatStateMachineScripts.State
{
    public class CombatOnState : CombatBaseState
    {
        public CombatOnState(CombatStateMachine combatStateMachine, CombatStateFactory factory) : base(combatStateMachine, factory)
        {
            _isRoot = true;
        }

        public override void StartState()
        {
            InitSubSet();
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
           
        }

        public override void InitSubSet()
        {
            SetSubState(_factory.Wait());
        }

        public override void CheckSwitchState()
        {
            
        }
    }
}