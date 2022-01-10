

using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace EnemyStateMachineScripts.State.SubState
{
    public class EnemyKeepDistanceState : EnemyBaseState
    {
        private float _counter = 0;
        public EnemyKeepDistanceState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(enemyStateMachine, factory)
        {
        }

        public override void StartState()
        {
            _enemyStateMachine.AttackTime = 0;
            _enemyStateMachine.TargetSpeed = _enemyStateMachine.SpeedFactor;
            _enemyStateMachine.NavMeshAgent.isStopped = true;
        }

        public override void UpdateState()
        {
            Vector3 relativePos = _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position - _enemyStateMachine.EnemyCharacterActor.Position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            _enemyStateMachine.RotationQuaternion = rotation;

            if (Vector3.Distance(_enemyStateMachine.EnemyCharacterActor.Position,
                    _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position) < _enemyStateMachine.CombatStateMachine.Range + 1)
            {
                _enemyStateMachine.MoveVelocity =
                    _enemyStateMachine.EnemyCharacterActor.Forward * _enemyStateMachine.Speed * -1;
            }
            else
            {
                _enemyStateMachine.MoveVelocity =
                    _enemyStateMachine.EnemyCharacterActor.Forward * _enemyStateMachine.Speed * -1;
            }

            _counter += Time.deltaTime;
            CheckSwitchState();
        }

        public override void EndState()
        {
            _enemyStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void InitSubSet()
        {
        }

        public override void CheckSwitchState()
        {
            if (_counter >= 2f && _enemyStateMachine.Stamina >= 30)
            {
                SwitchState(_factory.Walk());
            }
        }
    }
}