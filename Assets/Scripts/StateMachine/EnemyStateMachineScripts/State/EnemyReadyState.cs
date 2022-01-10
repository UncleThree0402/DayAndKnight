using UnityEngine;

namespace EnemyStateMachineScripts.State
{
    public class EnemyReadyState : EnemyBaseState
    {
        public EnemyReadyState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(enemyStateMachine,
            factory)
        {
            _isRoot = true;
        }

        public override void StartState()
        {
            _enemyStateMachine.TargetSpeed = 0.0f;
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
        }

        public override void CheckSwitchState()
        {
            if (_enemyStateMachine.TargetRandom.CurrentTarget != null)
            {
                SwitchState(_factory.Combat());
            }
            else if (_enemyStateMachine.Health <= 0.0f)
            {
                SwitchState(_factory.Die());
            }
        }
    }
}