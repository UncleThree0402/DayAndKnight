using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controller
{
    public class PlayerGameController : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        public void MoveAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Move.started += method;
            _playerInput.CharacterControls.Move.performed += method;
            _playerInput.CharacterControls.Move.canceled += method;
        }
        
        public void MoveDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Move.started -= method;
            _playerInput.CharacterControls.Move.performed -= method;
            _playerInput.CharacterControls.Move.canceled -= method;
        }
        
        public void KeyLShiftAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Run.started += method;
            _playerInput.CharacterControls.Run.performed += method;
            _playerInput.CharacterControls.Run.canceled += method;
        }
        
        public void KeyLShiftDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Run.started -= method;
            _playerInput.CharacterControls.Run.performed -= method;
            _playerInput.CharacterControls.Run.canceled -= method;
        }
        
        public void KeyLCltAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Crouch.started += method;
            _playerInput.CharacterControls.Crouch.performed += method;
            _playerInput.CharacterControls.Crouch.canceled += method;
        }
        
        public void KeyLCltDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Crouch.started -= method;
            _playerInput.CharacterControls.Crouch.performed -= method;
            _playerInput.CharacterControls.Crouch.canceled -= method;
        }
        
        public void KeyCAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Roll.started += method;
            _playerInput.CharacterControls.Roll.performed += method;
            _playerInput.CharacterControls.Roll.canceled += method;
        }
        
        public void KeyCDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Roll.started -= method;
            _playerInput.CharacterControls.Roll.performed -= method;
            _playerInput.CharacterControls.Roll.canceled -= method;
        }
        
        public void KeySpaceAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Jump.started += method;
            _playerInput.CharacterControls.Jump.performed += method;
            _playerInput.CharacterControls.Jump.canceled += method;
        }
        
        public void KeySpaceDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Jump.started -= method;
            _playerInput.CharacterControls.Jump.performed -= method;
            _playerInput.CharacterControls.Jump.canceled -= method;
        }
        
        public void KeyLAltAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.CombatMode.started += method;
            _playerInput.CharacterControls.CombatMode.performed += method;
            _playerInput.CharacterControls.CombatMode.canceled += method;
        }
        
        public void KeyLAltDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.CombatMode.started -= method;
            _playerInput.CharacterControls.CombatMode.performed -= method;
            _playerInput.CharacterControls.CombatMode.canceled -= method;
        }
        
        public void KeyLMouseAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Attack.started += method;
            _playerInput.CharacterControls.Attack.performed += method;
            _playerInput.CharacterControls.Attack.canceled += method;
        }
        
        public void KeyLMouseDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Attack.started -= method;
            _playerInput.CharacterControls.Attack.performed -= method;
            _playerInput.CharacterControls.Attack.canceled -= method;
        }
        
        public void KeyRMouseAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Block.started += method;
            _playerInput.CharacterControls.Block.performed += method;
            _playerInput.CharacterControls.Block.canceled += method;
        }
        
        public void KeyRMouseDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Block.started -= method;
            _playerInput.CharacterControls.Block.performed -= method;
            _playerInput.CharacterControls.Block.canceled -= method;
        }
        
        public void Key1Attach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Combo1.started += method;
            _playerInput.CharacterControls.Combo1.performed += method;
            _playerInput.CharacterControls.Combo1.canceled += method;
        }
        
        public void Key1Detach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Combo1.started -= method;
            _playerInput.CharacterControls.Combo1.performed -= method;
            _playerInput.CharacterControls.Combo1.canceled -= method;
        }
        
        public void Key2Attach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Combo2.started += method;
            _playerInput.CharacterControls.Combo2.performed += method;
            _playerInput.CharacterControls.Combo2.canceled += method;
        }
        
        public void Key2Detach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Combo2.started -= method;
            _playerInput.CharacterControls.Combo2.performed -= method;
            _playerInput.CharacterControls.Combo2.canceled -= method;
        }
        
        public void Key3Attach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Combo3.started += method;
            _playerInput.CharacterControls.Combo3.performed += method;
            _playerInput.CharacterControls.Combo3.canceled += method;
        }
        
        public void Key3Detach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Combo3.started -= method;
            _playerInput.CharacterControls.Combo3.performed -= method;
            _playerInput.CharacterControls.Combo3.canceled -= method;
        }
        
        public void Key4Attach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Combo4.started += method;
            _playerInput.CharacterControls.Combo4.performed += method;
            _playerInput.CharacterControls.Combo4.canceled += method;
        }
        
        public void Key4Detach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.CharacterControls.Combo4.started -= method;
            _playerInput.CharacterControls.Combo4.performed -= method;
            _playerInput.CharacterControls.Combo4.canceled -= method;
        }
        
        private void OnEnable()
        {
            _playerInput.CharacterControls.Enable();
        }

        private void OnDisable()
        {
            _playerInput.CharacterControls.Disable();
        }
    }
}