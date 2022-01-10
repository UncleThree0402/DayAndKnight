using AnimatorScripts;
using Interfaces.CharacterBehaviour;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace EnemyStateMachineScripts.State.SubState.AttackState
{
    public class EnemyNormalAttackState : EnemyBaseState
    {
        private int isTran = 0;
        private bool isCounted = false;
        public EnemyNormalAttackState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(enemyStateMachine, factory)
        {
        }

        public override void StartState()
        {
            Debug.Log("na");
            _enemyStateMachine.AttackTime++;
            _enemyStateMachine.TargetSpeed = _enemyStateMachine.SpeedFactor;
            _enemyStateMachine.NavMeshAgent.isStopped = false;
            _enemyStateMachine.CombatStateMachine.IsAttack = true;
        }

        public override void UpdateState()
        {
            Vector3 relativePos = _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position - _enemyStateMachine.EnemyCharacterActor.Position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            _enemyStateMachine.RotationQuaternion = rotation;
            _enemyStateMachine.NavMeshAgent.speed = _enemyStateMachine.Speed;
            _enemyStateMachine.NavMeshAgent.destination = _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position;
            CheckSwitchState();
        }

        public override void EndState()
        {
            _enemyStateMachine.CombatStateMachine.IsAttack = false;
            _enemyStateMachine.NavMeshAgent.isStopped = true;
            _enemyStateMachine.TargetSpeed = 0;
        }

        public override void InitSubSet()
        {
            
        }

        public override void CheckSwitchState()
        {
            if (!_enemyStateMachine.CombatStateMachine.IsAttacking)
            {
                SwitchState(_factory.Walk());
            }
        }
    }
}