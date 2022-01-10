using System.Collections;
using System.Collections.Generic;
using PlayerController;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerBaseState _superSet;
    protected PlayerBaseState _subSet;
    protected PlayerStateMachine _playerStateMachine;
    protected PlayerStateFactory _factory;

    protected bool _isRoot = false;

    protected PlayerBaseState(PlayerStateMachine playerStateMachine, PlayerStateFactory builder)
    {
        _playerStateMachine = playerStateMachine;
        _factory = builder;
    }

    public abstract void StartState();

    public abstract void UpdateState();

    public abstract void EndState();

    public abstract void InitSubSet();

    public abstract void CheckSwitchState();

    public void StartStates()
    {
        StartState();
        if (_subSet != null)
        {
            _subSet.StartStates();
        }
    }

    public void UpdateStates()
    {
        UpdateState();
        if (_subSet != null)
        {
            _subSet.UpdateStates();
        }
    }

    public void EndStates()
    {
        EndState();
        if (_subSet != null)
        {
            _subSet.EndStates();
        }
    }

    protected void SwitchState(PlayerBaseState state)
    {
        EndStates();
        state.StartStates();

        if (_isRoot)
        {
            _playerStateMachine.CurrentState = state;
        }
        else if (_superSet != null)
        {
            _superSet.SetSubState(state);
        }
    }

    protected void SetSuperState(PlayerBaseState state)
    {
        _superSet = state;
    }

    protected void SetSubState(PlayerBaseState state)
    {
        _subSet = state;
        _subSet.SetSuperState(this);
    }
}