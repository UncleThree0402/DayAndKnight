using System;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        private GameObject _currentCanvas;
        [SerializeField]
        private List<GameObject> _currentCanvasList;

        private PlayerUIController _playerUIController;

        private bool isMenu = false;

        private void Start()
        {
            _playerUIController = FindObjectOfType<PlayerUIController>();
            _currentCanvasList[0].SetActive(true);
            Debug.Log(_currentCanvasList[0]);
            _currentCanvas = _currentCanvasList[0];
            _playerUIController.KeyMAttach(MapOpenClose);
            _playerUIController.KeyEscAttach(MenuOpenClose);
        }

        public void Game()
        {
            FindObjectOfType<CursorController>().DisableCursor();
            _currentCanvas.SetActive(false);
            _currentCanvasList[0].SetActive(true);
            _currentCanvas = _currentCanvasList[0];
        }

        public void Die()
        {
            FindObjectOfType<CursorController>().EnableCursor();
            _currentCanvas.SetActive(false);
            _currentCanvasList[1].SetActive(true);
            _currentCanvas = _currentCanvasList[1];
        }

        public void Map()
        {
            FindObjectOfType<CursorController>().DisableCursor();
            _currentCanvas.SetActive(false);
            _currentCanvasList[2].SetActive(true);
            _currentCanvas = _currentCanvasList[2];
        }
        
        public void Win()
        {
            FindObjectOfType<CursorController>().EnableCursor();
            _currentCanvas.SetActive(false);
            _currentCanvasList[3].SetActive(true);
            _currentCanvas = _currentCanvasList[3];
        }

        public void GameMenu()
        {
            FindObjectOfType<CursorController>().EnableCursor();
            _currentCanvas.SetActive(false);
            _currentCanvasList[4].SetActive(true);
            _currentCanvas = _currentCanvasList[4];
        }
        
        public void Control()
        {
            FindObjectOfType<CursorController>().EnableCursor();
            _currentCanvas.SetActive(false);
            _currentCanvasList[5].SetActive(true);
            _currentCanvas = _currentCanvasList[5];
        }

        private void MapOpenClose(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                Map();
            }
            else
            {
                Game();
            }
        }
        
        private void MenuOpenClose(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                if (isMenu)
                {
                    Game();
                    isMenu = false;
                }
                else
                {
                    GameMenu();
                    isMenu = true;
                }
            }
        }
    }
}