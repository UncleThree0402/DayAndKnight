using System;
using AnimatorScripts;
using Interfaces;
using Interfaces.CharacterBehaviour;
using Interfaces.Observer;
using Interfaces.WeaponBehaviour;
using InventoryScripts;
using StateMachine.CombatStateMachineScripts.State;
using Stats;
using UnityEngine;

namespace StateMachine.CombatStateMachineScripts
{
    public class CombatStateMachine : MonoBehaviour, IObserver
    {
        private CombatBaseState _currentState;

        private CombatStateFactory _factory;

        [SerializeField]
        private Animator _animator;

        private IWeapon _weapon;

        private ICanMove _canMove;

        private float _range;

        //Stats
        private float _health;
        private float _Stamina;
        
        //bool
        private bool _isAttack;
        private bool _isBlock;
        private bool _isCombo1;
        private bool _isCombo2;
        private bool _isCombo3;
        private bool _isCombo4;
        private bool _isAttacking = false;

        //Timer
        private float _combo1Time = 0;
        private float _combo2Time = 0;
        private float _combo3Time = 0;
        private float _combo4Time = 0;

        protected event EventHandler ColdDown;
        
        
        private void Awake()
        {
            _factory = new CombatStateFactory(this);
        }

        private void Start()
        {
            _canMove = GetComponent<ICanMove>();
            GetComponent<IObservable>().Attach(this);
            _weapon = GetComponent<BodySlots>().Weapon.transform.GetChild(0).GetComponent<IWeapon>();
            _weapon.TeamTag = gameObject.tag;
            _range = _weapon.Range;
            
            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 1);
            _animator.SetLayerWeight(3, 1);
            _animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsCombat),true);
            _weapon.SetWeaponTypeTrue(_animator);

            ColdDown += Combo1ColdDown;
            ColdDown += Combo2ColdDown;
            ColdDown += Combo3ColdDown;
            ColdDown += Combo4ColdDown;
            
            _currentState = _factory.On();
            _currentState.StartStates();
        }

        private void Update()
        {
            ColdDown?.Invoke(this,EventArgs.Empty);
            _currentState.UpdateStates();
        }

        public void UpdateData(IObservable observable)
        {
            if (observable is BasicStats basicStats)
            {
                _health = basicStats.Health;
                _Stamina = basicStats.Stamina;
            }
        }

        protected void Combo1ColdDown(object sender, EventArgs e)
        {
            if (_combo1Time > 0)
            {
                _combo1Time = Mathf.Clamp(_combo1Time - Time.deltaTime, 0, 15);
            }
        }
        
        protected void Combo2ColdDown(object sender, EventArgs e)
        {
            if (_combo2Time > 0)
            {
                _combo2Time = Mathf.Clamp(_combo2Time - Time.deltaTime, 0, 10);
            }
        }
        
        protected void Combo3ColdDown(object sender, EventArgs e)
        {
            if (_combo3Time > 0)
            {
                _combo3Time = Mathf.Clamp(_combo3Time - Time.deltaTime, 0, 10);
            }
        }
        
        protected void Combo4ColdDown(object sender, EventArgs e)
        {
            if (_combo4Time > 0)
            {
                _combo4Time = Mathf.Clamp(_combo4Time - Time.deltaTime, 0, 5);
            }
        }
        
        private void OnEnable()
        {
            _currentState = _factory.On();
            _currentState.StartStates();
            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 1);
            _animator.SetLayerWeight(3, 1);
            _animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsCombat),true);
            if (_weapon != null)
            {
                _weapon.SetWeaponTypeTrue(_animator);
            }
        }

        private void OnDisable()
        {
            _currentState.EndStates();
            _animator.SetBool(AnimatorHash.GetHash(AnimationHash.IsCombat), false);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _weapon.SetWeaponTypeFalse(_animator);
        }

        public float Range => _range;

        public float Combo1Time
        {
            get => _combo1Time;
            set => _combo1Time = value;
        }

        public float Combo2Time
        {
            get => _combo2Time;
            set => _combo2Time = value;
        }

        public float Combo3Time
        {
            get => _combo3Time;
            set => _combo3Time = value;
        }

        public float Combo4Time
        {
            get => _combo4Time;
            set => _combo4Time = value;
        }

        public bool IsAttack
        {
            get => _isAttack;
            set => _isAttack = value;
        }

        public bool IsAttacking
        {
            get => _isAttacking;
            set => _isAttacking = value;
        }

        public bool IsBlock
        {
            get => _isBlock;
            set => _isBlock = value;
        }

        public bool IsCombo1
        {
            get => _isCombo1;
            set => _isCombo1 = value;
        }

        public bool IsCombo2
        {
            get => _isCombo2;
            set => _isCombo2 = value;
        }

        public bool IsCombo3
        {
            get => _isCombo3;
            set => _isCombo3 = value;
        }

        public bool IsCombo4
        {
            get => _isCombo4;
            set => _isCombo4 = value;
        }

        public IWeapon Weapon => _weapon;

        public float Health
        {
            get => _health;
            set => _health = value;
        }

        public float Stamina
        {
            get => _Stamina;
            set => _Stamina = value;
        }

        public CombatBaseState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        public Animator Animator
        {
            get => _animator;
            set => _animator = value;
        }

        public ICanMove CanMove
        {
            get => _canMove;
            set => _canMove = value;
        }
    }
}