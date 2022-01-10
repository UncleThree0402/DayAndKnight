using System;
using AnimatorScripts;
using ColliderScripts;
using Combat;
using EnemyStateMachineScripts.State;
using Interfaces;
using Interfaces.Observer;
using Interfaces.WeaponBehaviour;
using InventoryScripts;
using Lightbug.CharacterControllerPro.Core;
using StateMachine.CombatStateMachineScripts;
using Stats;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyStateMachineScripts
{
    public class EnemyStateMachine : MonoBehaviour, IObserver ,ICanRotate, ICanMove, IHaveGravity
    {
        //Character Actor
        [SerializeField] private CharacterActor enemyCharacterActor;

        [SerializeField] private BodySlots _bodySlots;

        [SerializeField] private TargetRandom _targetRandom;
        
        //Speed Factor
        [SerializeField] private float speedFactor;

        [SerializeField] private NavMeshAgent _navMeshAgent;

        [SerializeField] private CombatStateMachine _combatStateMachine;
        
    
        //Observable
        private IObservable _observable;

        private int _health;
        private int _stamina;

        //Speed
        private float _speed = 0;

        //Target Speed
        private float _targetSpeed = 0.0f;
    
        //Current Vertical Acceleration
        private float _verticalAcceleration = 0;

        //RotateSpeed
        private float _rotateSpeed = 5.0f;
        
        //Counter
        private int _AttackTime = 0;

        //Animator
        private Animator _animator;

        //State Factory
        private EnemyStateFactory _factory;

        //CurrentState
        private EnemyBaseState _currentState;

        //Rotation
        private Quaternion _rotationQuaternion = Quaternion.identity;

        //Velocity
        private Vector3 _moveVelocity;
        
        //Tran Time
        private int _normalTrans;
        private int _combo1Trans;
        private int _combo2Trans;
        private int _combo3Trans;
        private int _combo4Trans;

        //Bool
        private bool _isCanMove;
        
        public bool CanMove
        {
            get
            {
                return _isCanMove;
            }
            set
            {
                _isCanMove = value;
            }
        }

        private void Awake()
        {
            _factory = new EnemyStateFactory(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = transform.GetChild(0).GetComponent<Animator>();
            _currentState = _factory.Ready();
        }

        private void Start()
        {
            enemyCharacterActor.IsKinematic = true;
            GetComponent<IObservable>().Attach(this);
            _normalTrans = _bodySlots.Weapon.transform.GetChild(0).GetComponent<IWeapon>().BasicAttackTran();
            _combo1Trans = _bodySlots.Weapon.transform.GetChild(0).GetComponent<IWeapon>().Combo1Tran();
            _combo2Trans = _bodySlots.Weapon.transform.GetChild(0).GetComponent<IWeapon>().Combo2Tran();
            _combo3Trans = _bodySlots.Weapon.transform.GetChild(0).GetComponent<IWeapon>().Combo3Tran();
            _combo4Trans = _bodySlots.Weapon.transform.GetChild(0).GetComponent<IWeapon>().Combo4Tran();
            _currentState.StartStates();
        }

        private void Update()
        {
            _currentState.UpdateStates();
            HandleSpeed(_targetSpeed, ref _speed);
            Rotate(enemyCharacterActor, _rotationQuaternion);
            Move(enemyCharacterActor, _moveVelocity);
            Animator.SetFloat(AnimatorHash.GetHash(AnimationHash.Velocity), _speed / (speedFactor* 2f) * 100f);
        }

        private void HandleSpeed(float target, ref float current)
        {
            if (target < current)
            {
                current += -10f * Time.deltaTime;
            }
            else if (target > current)
            {
                current += 5f * Time.deltaTime;
            }
        }
        
        public void Rotate(CharacterActor actor, Quaternion quaternion)
        {
            actor.Rotation = Quaternion.Slerp(actor.Rotation, quaternion , _rotateSpeed * Time.deltaTime);
        }

        public void Move(CharacterActor actor, Vector3 velocity)
        {
            actor.Velocity = Gravity(actor, velocity);
        }

        public float UnderSlope(CharacterActor actor)
        {
            if (actor.GroundSlopeAngle == 0.0f)
            {
                return 1.0f;
            }
            else if (actor.PostSimulationVelocity.y > -0.1962f)
            {
                return 1.0f - (float) Math.Pow(5.0f, ((actor.GroundSlopeAngle / actor.slopeLimit) * 2) - 2);
            }
            else
            {
                return 1.0f + (float) Math.Pow(5.0f, ((actor.GroundSlopeAngle / actor.slopeLimit) * 2) - 2);
            }
        }

        public Vector3 Gravity(CharacterActor actor, Vector3 velocity)
        {
            if (actor.IsGrounded && !actor.IsStable)
            {
                _verticalAcceleration -= 9.81f * Time.deltaTime;
                velocity.y += _verticalAcceleration;
            }
            else if (actor.IsGrounded && actor.IsStable)
            {
                _verticalAcceleration = 0;
                velocity.y = _verticalAcceleration;
            }
            else
            {
                velocity.y = actor.RigidbodyComponent.Velocity.y;
            }

            return velocity;
        }

        public void UpdateData(IObservable observable)
        {
            if (observable is BasicStats enemyStats)
            {
                _health = (int)Math.Round(enemyStats.Health);
                _stamina = (int)Math.Round(enemyStats.Stamina);
            }
        }

        public int AttackTime
        {
            get => _AttackTime;
            set => _AttackTime = value;
        }

        public EnemyBaseState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        public TargetRandom TargetRandom => _targetRandom;

        public Quaternion RotationQuaternion
        {
            get => _rotationQuaternion;
            set => _rotationQuaternion = value;
        }

        public Vector3 MoveVelocity
        {
            get => _moveVelocity;
            set => _moveVelocity = value;
        }

        public CharacterActor EnemyCharacterActor
        {
            get => enemyCharacterActor;
            set => enemyCharacterActor = value;
        }

        public float TargetSpeed
        {
            get => _targetSpeed;
            set => _targetSpeed = value;
        }

        public float SpeedFactor
        {
            get => speedFactor;
            set => speedFactor = value;
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public Animator Animator
        {
            get => _animator;
            set => _animator = value;
        }

        public NavMeshAgent NavMeshAgent
        {
            get => _navMeshAgent;
            set => _navMeshAgent = value;
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public int Stamina
        {
            get => _stamina;
            set => _stamina = value;
        }

        public BodySlots BodySlots => _bodySlots;

        public int NormalTrans => _normalTrans;

        public int Combo1Trans => _combo1Trans;

        public int Combo2Trans => _combo2Trans;

        public int Combo3Trans => _combo3Trans;

        public int Combo4Trans => _combo4Trans;

        public CombatStateMachine CombatStateMachine => _combatStateMachine;
    }
}