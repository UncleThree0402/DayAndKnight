using AnimatorScripts;
using Stats;
using UnityEngine;

namespace EnemyStateMachineScripts.State
{
    public class EnemyDieState : EnemyBaseState
    {
        public EnemyDieState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(enemyStateMachine,
            factory)
        {
        }

        public override void StartState()
        {
            _enemyStateMachine.Animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsDie), true);
            _enemyStateMachine.MoveVelocity = Vector3.zero;
            _enemyStateMachine.EnemyCharacterActor.IsKinematic = true;
            _enemyStateMachine.GetComponent<BasicStats>().HealthGenRate.baseValue = 0;
            _enemyStateMachine.GetComponent<BasicStats>().StaminaGenRate.baseValue = 0;
        }

        public override void UpdateState()
        {
            GameObject.Destroy(_enemyStateMachine.gameObject, 10f);
        }

        public override void EndState()
        {
        }

        public override void InitSubSet()
        {
        }

        public override void CheckSwitchState()
        {
        }
    }
}