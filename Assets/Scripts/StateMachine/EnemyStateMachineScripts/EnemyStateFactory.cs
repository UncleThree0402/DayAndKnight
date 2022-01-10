using EnemyStateMachineScripts.State;
using EnemyStateMachineScripts.State.SubState;
using EnemyStateMachineScripts.State.SubState.AttackState;

namespace EnemyStateMachineScripts
{
    public class EnemyStateFactory
    {
        private EnemyStateMachine _enemyStateMachine;
        public EnemyStateFactory(EnemyStateMachine enemyStateMachine)
        {
            _enemyStateMachine = enemyStateMachine;
        }

        public EnemyBaseState Ready()
        {
            return new EnemyReadyState(_enemyStateMachine, this);
        }
        
        public EnemyBaseState Combat()
        {
            return new EnemyCombatState(_enemyStateMachine, this);
        }
        
        public EnemyBaseState Die()
        {
            return new EnemyDieState(_enemyStateMachine, this);
        }
        
        
        public EnemyBaseState Chasing()
        {
            return new EnemyChasingState(_enemyStateMachine, this);
        }
        
        public EnemyBaseState Engage()
        {
            return new EnemyEngageState(_enemyStateMachine, this);
        }
        
        public EnemyBaseState Walk()
        {
            return new EnemyWalkState(_enemyStateMachine, this);
        }
        
        public EnemyBaseState KeepDistance()
        {
            return new EnemyKeepDistanceState(_enemyStateMachine, this);
        }
        
        
        public EnemyBaseState NormalAttack()
        {
            return new EnemyNormalAttackState(_enemyStateMachine, this);
        }
        
        public EnemyBaseState Combo1()
        {
            return new EnemyCombo1State(_enemyStateMachine, this);
        }
        
        public EnemyBaseState Combo2()
        {
            return new EnemyCombo2State(_enemyStateMachine, this);
        }
        
        public EnemyBaseState Combo3()
        {
            return new EnemyCombo3State(_enemyStateMachine, this);
        }
        
        public EnemyBaseState Combo4()
        {
            return new EnemyCombo4State(_enemyStateMachine, this);
        }
        
    }
}