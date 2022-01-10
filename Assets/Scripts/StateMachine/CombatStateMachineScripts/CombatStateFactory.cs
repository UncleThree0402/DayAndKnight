using StateMachine.CombatStateMachineScripts.State;
using StateMachine.CombatStateMachineScripts.State.SubState;

namespace StateMachine.CombatStateMachineScripts
{
    public class CombatStateFactory
    {
        private CombatStateMachine _combatStateMachine;

        public CombatStateFactory(CombatStateMachine combatStateMachine)
        {
            _combatStateMachine = combatStateMachine;
        }

        public CombatBaseState On()
        {
            return new CombatOnState(_combatStateMachine, this);
        }
        
        public CombatBaseState Attack()
        {
            return new CombatAttackState(_combatStateMachine, this);
        }
        
        public CombatBaseState Block()
        {
            return new CombatBlockState(_combatStateMachine, this);
        }
        
        public CombatBaseState Combo1()
        {
            return new CombatCombo1State(_combatStateMachine, this);
        }
        
        public CombatBaseState Combo2()
        {
            return new CombatCombo2State(_combatStateMachine, this);
        }
        
        public CombatBaseState Combo3()
        {
            return new CombatCombo3State(_combatStateMachine, this);
        }
        
        public CombatBaseState Combo4()
        {
            return new CombatCombo4State(_combatStateMachine, this);
        }
        
        public CombatBaseState Wait()
        {
            return new CombatWaitState(_combatStateMachine, this);
        }
    }
}