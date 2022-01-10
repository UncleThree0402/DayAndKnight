using System;
using AnimatorScripts;
using ColliderScripts;
using Controller;
using Interfaces;
using Interfaces.Observer;
using Lightbug.CharacterControllerPro.Core;
using PlayerController;
using Stats;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class PlayerStateMachine : MonoBehaviour,IObserver ,ICanRotate, ICanMove, IHaveGravity
{
    //Character Actor
    [SerializeField] private CharacterActor characterActor;
    
    private PlayerGameController _playerController;
    
    //Detector
    [SerializeField] private TargetCollider _targetCollider;
    
    //Camera Transform
    [SerializeField] private Transform cameraTransform;

    //Speed Factor
    [SerializeField] private float speedFactor;
    
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

    //Animator
    private Animator _animator;

    //State Factory
    private PlayerStateFactory _factory;

    //CurrentState
    private PlayerBaseState _currentState;

    //Rotation
    private Quaternion _rotationQuaternion = Quaternion.identity;

    //Velocity
    private Vector3 _moveVelocity;

    //Direction
    private Vector2 _moveTarget;
    private Vector2 _moveCurrent;

    //Direction Input
    private Vector2 _directionInput;

    //BoolState
    private bool _isWalkPress;
    private bool _isRunPress;
    private bool _isJumpPress;
    private bool _isCrouchPress;
    private bool _isRollPress;
    private bool _isCombatModePress;
    private bool _isLockCam;
    public bool _isCanMove = true;

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
        _factory = new PlayerStateFactory(this);
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _currentState = _factory.Healthy();
    }

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerGameController>();
        PlayerInputInit();
        GetComponent<IObservable>().Attach(this);
        characterActor.RigidbodyComponent.UseGravity = true;
        _currentState.StartStates();
    }

    private void Update()
    {
        _currentState.UpdateStates();
        if (_isCanMove)
        {
            HandleSpeed(_targetSpeed, ref _speed);
            HandleXY();
            Rotate(characterActor, _rotationQuaternion);
            Move(characterActor, _moveVelocity);
        }
        else
        {
            Move(characterActor, Vector3.zero);
        }
    }

    public void UpdateData(IObservable observable)
    {
        if (observable is PlayerStats playerStats)
        {
            _health = (int)Math.Round(playerStats.Health);
            _stamina = (int)Math.Round(playerStats.Stamina);
        }
    }

    public void Rotate(CharacterActor actor, Quaternion quaternion)
    {
        actor.Rotation = Quaternion.Slerp(actor.Rotation, quaternion, _rotateSpeed * Time.deltaTime);
    }

    public void Move(CharacterActor actor, Vector3 velocity)
    {
        actor.Velocity = Gravity(actor, velocity);
        Animator.SetFloat(AnimatorHash.GetHash(AnimationHash.Velocity), _speed / (speedFactor* 2f) * 100f);
        Animator.SetFloat(AnimatorHash.GetHash(AnimationHash.VelocityX),(float) (Math.Round(((_moveCurrent.x * _speed) / (speedFactor * 2f) * 100f))));
        Animator.SetFloat(AnimatorHash.GetHash(AnimationHash.VelocityZ),  (float) (Math.Round(((_moveCurrent.y * _speed) / (speedFactor * 2f) * 100f))));
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


    private void HandleXY()
    {
        float rotationAcceleration;

        if (DirectionInput.x == 0 && DirectionInput.y == 0)
        {
            rotationAcceleration = 0.5f;
        }
        else
        {
            rotationAcceleration = 5f;
        }

        _moveTarget.x = DirectionInput.x;
        _moveTarget.y = DirectionInput.y;

        if (_moveTarget.x > _moveCurrent.x)
        {
            _moveCurrent.x += rotationAcceleration * Time.deltaTime;
        }
        else if (_moveTarget.x < _moveCurrent.x)
        {
            _moveCurrent.x -= rotationAcceleration * Time.deltaTime;
        }

        if (_moveTarget.y > _moveCurrent.y)
        {
            _moveCurrent.y += rotationAcceleration * Time.deltaTime;
        }
        else if (_moveTarget.y < _moveCurrent.y)
        {
            _moveCurrent.y -= rotationAcceleration * Time.deltaTime;
        }
    }

    private void PlayerInputInit()
    {
        _playerController.MoveAttach(OnMove);
        _playerController.KeyLShiftAttach(OnRun);
        _playerController.KeyLCltAttach(OnCrouch);
        _playerController.KeyCAttach(OnRoll);
        _playerController.KeySpaceAttach(OnJump);
        _playerController.KeyLAltAttach(OnCombatMode);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _directionInput = context.ReadValue<Vector2>();
        if (_directionInput.x == 0 && _directionInput.y == 0)
        {
            _isWalkPress = false;
        }
        else
        {
            _isWalkPress = true;
        }
    }
    
    private void OnCombatMode(InputAction.CallbackContext context)
    {
        _isCombatModePress = context.ReadValueAsButton();
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        _isRunPress = context.ReadValueAsButton();
    }

    private void OnCrouch(InputAction.CallbackContext context)
    {
        _isCrouchPress = context.ReadValueAsButton();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _isJumpPress = context.ReadValueAsButton();
    }

    private void OnRoll(InputAction.CallbackContext context)
    {
        _isRollPress = context.ReadValueAsButton();
    }

    //Getter and Setter
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

    public float SpeedFactor => speedFactor;

    public bool IsWalkPress => _isWalkPress;

    public bool IsRunPress => _isRunPress;

    public bool IsJumpPress => _isJumpPress;

    public bool IsCrouchPress => _isCrouchPress;

    public bool IsRollPress => _isRollPress;

    public bool IsCombatModePress => _isCombatModePress;

    public PlayerBaseState CurrentState
    {
        get => _currentState;
        set => _currentState = value;
    }

    public TargetCollider TargetCollider
    {
        get => _targetCollider;
        set => _targetCollider = value;
    }

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

    public Vector2 MoveTarget
    {
        get => _moveTarget;
        set => _moveTarget = value;
    }

    public Vector2 MoveCurrent
    {
        get => _moveCurrent;
        set => _moveCurrent = value;
    }

    public Vector2 DirectionInput
    {
        get => _directionInput;
        set => _directionInput = value;
    }

    public Animator Animator
    {
        get => _animator;
        set => _animator = value;
    }

    public Transform CameraTransform
    {
        get => cameraTransform;
        set => cameraTransform = value;
    }

    public CharacterActor CharacterActor
    {
        get => characterActor;
        set => characterActor = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float TargetSpeed
    {
        get => _targetSpeed;
        set => _targetSpeed = value;
    }

    public float RotateSpeed
    {
        get => _rotateSpeed;
        set => _rotateSpeed = value;
    }
}