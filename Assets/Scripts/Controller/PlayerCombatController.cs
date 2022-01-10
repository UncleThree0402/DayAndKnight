using System;
using AnimatorScripts;
using Controller;
using Interfaces.WeaponBehaviour;
using InventoryScripts;
using StateMachine.CombatStateMachineScripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Combat
{
    public class PlayerCombatController : MonoBehaviour
    {
        [SerializeField] private CombatStateMachine _combatStateMachine;

        private PlayerGameController _playerGameController;
        
        private void Start()
        {
            _playerGameController = FindObjectOfType<PlayerGameController>();
            PlayerInputInit();
        }

        private void PlayerInputInit()
        {
            _playerGameController.KeyLMouseAttach(OnAttack);
            _playerGameController.KeyRMouseAttach(OnBlock);
            _playerGameController.Key1Attach(OnCombo1);
            _playerGameController.Key2Attach(OnCombo2);
            _playerGameController.Key3Attach(OnCombo3);
            _playerGameController.Key4Attach(OnCombo4);
        }

        private void OnAttack(InputAction.CallbackContext context)
        {
            _combatStateMachine.IsAttack = context.ReadValueAsButton();
        }

        private void OnBlock(InputAction.CallbackContext context)
        {
            _combatStateMachine.IsBlock = context.ReadValueAsButton();
        }

        private void OnCombo1(InputAction.CallbackContext context)
        {
            _combatStateMachine.IsCombo1 = context.ReadValueAsButton();
        }

        private void OnCombo2(InputAction.CallbackContext context)
        {
            _combatStateMachine.IsCombo2 = context.ReadValueAsButton();
        }

        private void OnCombo3(InputAction.CallbackContext context)
        {
            _combatStateMachine.IsCombo3 = context.ReadValueAsButton();
        }

        private void OnCombo4(InputAction.CallbackContext context)
        {
            _combatStateMachine.IsCombo4 = context.ReadValueAsButton();
        }
    }
}