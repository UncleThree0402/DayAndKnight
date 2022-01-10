using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace EnemyStateMachineScripts.State.SubState
{
    public class EnemyChasingState : EnemyBaseState
    {
        public EnemyChasingState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(enemyStateMachine, factory)
        {
        }

        public override void StartState()
        {
            Debug.Log("ca");
            _enemyStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void UpdateState()
        {
            _enemyStateMachine.TargetSpeed = _enemyStateMachine.SpeedFactor * 2.0f;
            _enemyStateMachine.NavMeshAgent.speed = _enemyStateMachine.Speed;
            _enemyStateMachine.NavMeshAgent.destination = _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position;
            CheckSwitchState();
        }

        public override void EndState()
        {
            _enemyStateMachine.NavMeshAgent.isStopped = true;
        }

        public override void InitSubSet()
        {
            
        }

        public override void CheckSwitchState()
        {
            if (Vector3.Distance(_enemyStateMachine.EnemyCharacterActor.Position,
                    _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position) < 5.0f)
            {
                SwitchState(_factory.Engage());
            }
        }
    }
}