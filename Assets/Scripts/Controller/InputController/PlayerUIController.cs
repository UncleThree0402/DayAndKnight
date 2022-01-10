using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controller
{
    public class PlayerUIController : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        public void KeyMAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.UIControls.Map.started += method;
            _playerInput.UIControls.Map.performed += method;
            _playerInput.UIControls.Map.canceled += method;
        }
        
        public void KeyMDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.UIControls.Map.started += method;
            _playerInput.UIControls.Map.performed += method;
            _playerInput.UIControls.Map.canceled += method;
        }
        
        public void KeyEscAttach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.UIControls.Menu.started += method;
        }
        
        public void KeyEscDetach(Action<InputAction.CallbackContext> method)
        {
            _playerInput.UIControls.Menu.started += method;
        }
        
        private void OnEnable()
        {
            _playerInput.UIControls.Enable();
        }

        private void OnDisable()
        {
            _playerInput.UIControls.Disable();
        }
        
    }
}