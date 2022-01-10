using AnimatorScripts;
using Interfaces.CharacterBehaviour;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace EnemyStateMachineScripts.State.SubState.AttackState
{
    public class EnemyCombo4State : EnemyBaseState
    {
        public EnemyCombo4State(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(enemyStateMachine, factory)
        {
        }

        public override void StartState()
        {
            _enemyStateMachine.AttackTime++;
            _enemyStateMachine.TargetSpeed = 0.0f;
            _enemyStateMachine.CombatStateMachine.IsCombo4 = true;
        }

        public override void UpdateState()
        {
            Vector3 relativePos = _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position - _enemyStateMachine.EnemyCharacterActor.Position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            _enemyStateMachine.RotationQuaternion = rotation;
            CheckSwitchState();
        }

        public override void EndState()
        {
            _enemyStateMachine.CombatStateMachine.IsCombo4 = false;
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