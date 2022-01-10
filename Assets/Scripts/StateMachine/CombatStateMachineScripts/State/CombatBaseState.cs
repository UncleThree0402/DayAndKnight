namespace StateMachine.CombatStateMachineScripts.State
{
    public abstract class CombatBaseState
    {
        protected CombatBaseState _superSet;
        protected CombatBaseState _subSet;
        protected CombatStateMachine _combatStateMachine;
        protected CombatStateFactory _factory;

        protected bool _isRoot = false;

        protected CombatBaseState(CombatStateMachine combatStateMachine, CombatStateFactory factory)
        {
            _combatStateMachine = combatStateMachine;
            _factory = factory;
        }

        public abstract void StartState();

        public abstract void UpdateState();

        public abstract void EndState();

        public abstract void InitSubSet();

        public abstract void CheckSwitchState();

        public void StartStates()
        {
            StartState();
            if (_subSet != null)
            {
                _subSet.StartStates();
            }
        }

        public void UpdateStates()
        {
            UpdateState();
            if (_subSet != null)
            {
                _subSet.UpdateStates();
            }
        }

        public void EndStates()
        {
            EndState();
            if (_subSet != null)
            {
                _subSet.EndStates();
            }
        }

        protected void SwitchState(CombatBaseState state)
        {
            EndStates();
            state.StartStates();

            if (_isRoot)
            {
                _combatStateMachine.CurrentState = state;
            }
            else if (_superSet != null)
            {
                _superSet.SetSubState(state);
            }
        }

        protected void SetSuperState(CombatBaseState state)
        {
            _superSet = state;
        }

        protected void SetSubState(CombatBaseState state)
        {
            _subSet = state;
            _subSet.SetSuperState(this);
        }
    }
}