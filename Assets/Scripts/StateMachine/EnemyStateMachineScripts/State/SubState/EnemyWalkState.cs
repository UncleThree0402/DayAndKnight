using Lightbug.CharacterControllerPro.Core;
using UnityEngine;
using Random = System.Random;

namespace EnemyStateMachineScripts.State.SubState
{
    public class EnemyWalkState : EnemyBaseState
    {
        private Random _rand = new Random();

        public EnemyWalkState(EnemyStateMachine enemyStateMachine, EnemyStateFactory factory) : base(enemyStateMachine,
            factory)
        {
        }

        public override void StartState()
        {
            _enemyStateMachine.TargetSpeed = _enemyStateMachine.SpeedFactor;
            _enemyStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void UpdateState()
        {
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
                    _enemyStateMachine.TargetRandom.CurrentTarget.GetComponent<CharacterActor>().Position) < _enemyStateMachine.CombatStateMachine.Range && _enemyStateMachine.Stamina > 20 && _enemyStateMachine.AttackTime < 4)
            {
                int num = _rand.Next(0, 5);
                switch (num)
                {
                    case 0:
                        SwitchState(_factory.NormalAttack());
                        break;
                    case 1:
                        if (_enemyStateMachine.Stamina >= 50 && _enemyStateMachine.CombatStateMachine.Combo1Time == 0)
                        {
                            SwitchState(_factory.Combo1());
                        }
                        else
                        {
                            SwitchState(_factory.NormalAttack());
                        }

                        break;
                    case 2:
                        if (_enemyStateMachine.Stamina >= 30 && _enemyStateMachine.CombatStateMachine.Combo2Time == 0)
                        {
                            SwitchState(_factory.Combo2());
                        }
                        else
                        {
                            SwitchState(_factory.NormalAttack());
                        }

                        break;
                    case 3:
                        if (_enemyStateMachine.Stamina >= 30 && _enemyStateMachine.CombatStateMachine.Combo3Time == 0)
                        {
                            SwitchState(_factory.Combo3());
                        }
                        else
                        {
                            SwitchState(_factory.NormalAttack());
                        }

                        break;
                    case 4:
                        if (_enemyStateMachine.Stamina >= 20 && _enemyStateMachine.CombatStateMachine.Combo4Time == 0)
                        {
                            SwitchState(_factory.Combo4());
                        }
                        else
                        {
                            SwitchState(_factory.NormalAttack());
                        }

                        break;
                }
            }
            else if (_enemyStateMachine.Stamina < 20f || _enemyStateMachine.AttackTime >= 4)
            {
                SwitchState(_factory.KeepDistance());
            }
        }
    }
}