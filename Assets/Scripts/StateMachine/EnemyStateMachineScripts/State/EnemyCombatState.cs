using AnimatorScripts;
using ColliderScripts;
using Interfaces.WeaponBehaviour;
using InventoryScripts;
using Lightbug.CharacterControllerPro.Core;
using StateMachine.CombatStateMachineScripts;
using UnityEngine;

namespace EnemyStateMachineScripts.State
{
    public class EnemyCombatState : EnemyBaseState
    {
        public EnemyCombatState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(
            enemyStateMachine, factory)
        {
            _isRoot = true;
        }

        public override void StartState()
        {
            _enemyStateMachine.GetComponent<CombatStateMachine>().enabled = true;
            InitSubSet();
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
            _enemyStateMachine.AttackTime = 0;
            _enemyStateMachine.GetComponent<CombatStateMachine>().enabled = false;
        }

        public override void InitSubSet()
        {
            if (Vector3.Distance(_enemyStateMachine.EnemyCharacterActor.Position,
                    _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position) > 5)
            {
                SetSubState(_factory.Chasing());
            }
            else
            {
                SetSubState(_factory.Engage());
            }
        }

        public override void CheckSwitchState()
        {
            if (_enemyStateMachine.TargetRandom.CurrentTarget == null )
            {
                SwitchState(_factory.Ready());
            }
            else if (_enemyStateMachine.Health <= 0.0f)
            {
                SwitchState(_factory.Die());
            }
        }
    }
}