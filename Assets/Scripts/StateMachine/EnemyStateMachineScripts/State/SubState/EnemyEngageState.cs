using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace EnemyStateMachineScripts.State.SubState
{
    public class EnemyEngageState : EnemyBaseState
    {
        public EnemyEngageState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(enemyStateMachine, factory)
        {
        }

        public override void StartState()
        {
            Debug.Log("en");
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
            SetSubState(_factory.Walk());
        }

        public override void CheckSwitchState()
        {
            if (Vector3.Distance(_enemyStateMachine.EnemyCharacterActor.Position,
                    _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position) >8)
            {
                SwitchState(_factory.Chasing());
            }
        }
    }
}