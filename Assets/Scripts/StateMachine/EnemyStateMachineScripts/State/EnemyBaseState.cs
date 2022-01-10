using UnityEngine;

namespace EnemyStateMachineScripts.State
{
    public abstract class EnemyBaseState
    {
        protected EnemyBaseState _superSet;
        protected EnemyBaseState _subSet;
        protected EnemyStateMachine _enemyStateMachine;
        protected EnemyStateFactory _factory;

        protected bool _isRoot = false;

        protected EnemyBaseState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory)
        {
            _enemyStateMachine = enemyStateMachine;
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

        protected void SwitchState(EnemyBaseState state)
        {
            EndStates();

            if (_isRoot)
            {
                _enemyStateMachine.CurrentState = state;
                _subSet = null;
            }
            else if (_superSet != null)
            {
                _superSet.SetSubState(state);
                _subSet = null;
                state.SetSuperState(_superSet);
            }
            
            state.StartStates();
        }

        protected void SetSuperState(EnemyBaseState state)
        {
            _superSet = state;
        }

        protected void SetSubState(EnemyBaseState state)
        {
            _subSet = state;
            _subSet.SetSuperState(this);
        }
    }
}