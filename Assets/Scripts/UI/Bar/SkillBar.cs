using System;
using Interfaces.UI;
using StateMachine.CombatStateMachineScripts;
using StateMachine.CombatStateMachineScripts.State;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SkillBar : MonoBehaviour, ISkillBar
    {
        [SerializeField] private GameObject [] _gameObjects;

        [SerializeField] private CombatStateMachine _combatStateMachine;

        private void Update()
        {
            RefreshCoolDownImage();
            RefreshCoolDownText();
        }

        public void RefreshCoolDownImage()
        {
            if (_combatStateMachine.enabled)
            {
                _gameObjects[0].transform.GetChild(1).GetComponent<Image>().fillAmount = _combatStateMachine.Combo1Time / 15f;
                _gameObjects[1].transform.GetChild(1).GetComponent<Image>().fillAmount = _combatStateMachine.Combo2Time / 10f;
                _gameObjects[2].transform.GetChild(1).GetComponent<Image>().fillAmount = _combatStateMachine.Combo3Time / 10f;
                _gameObjects[3].transform.GetChild(1).GetComponent<Image>().fillAmount = _combatStateMachine.Combo4Time / 10f;
            }
            else
            {
                foreach (var VARIABLE in _gameObjects)
                {
                    VARIABLE.transform.GetChild(1).GetComponent<Image>().fillAmount = 1;
                }
            }
        }

        public void RefreshCoolDownText()
        {
            if (_combatStateMachine.enabled)
            {
                if (_combatStateMachine.Combo1Time > 0)
                {
                    _gameObjects[0].transform.GetChild(2).GetComponent<Text>().text = Math.Round(_combatStateMachine.Combo1Time, 1).ToString();
                }
                else
                {
                    _gameObjects[0].transform.GetChild(2).GetComponent<Text>().text = "";
                }
                
                if (_combatStateMachine.Combo2Time > 0)
                {
                    _gameObjects[1].transform.GetChild(2).GetComponent<Text>().text = Math.Round(_combatStateMachine.Combo2Time, 1).ToString();
                }
                else
                {
                    _gameObjects[1].transform.GetChild(2).GetComponent<Text>().text = "";
                }
                
                if (_combatStateMachine.Combo3Time > 0)
                {
                    _gameObjects[2].transform.GetChild(2).GetComponent<Text>().text = Math.Round(_combatStateMachine.Combo3Time, 1).ToString();
                }
                else
                {
                    _gameObjects[2].transform.GetChild(2).GetComponent<Text>().text = "";
                }
                
                if (_combatStateMachine.Combo4Time > 0)
                {
                    _gameObjects[3].transform.GetChild(2).GetComponent<Text>().text = Math.Round(_combatStateMachine.Combo4Time, 1).ToString();
                }
                else
                {
                    _gameObjects[3].transform.GetChild(2).GetComponent<Text>().text = "";
                }
            }
            else
            {
                _gameObjects[0].transform.GetChild(2).GetComponent<Text>().text = "";
                _gameObjects[1].transform.GetChild(2).GetComponent<Text>().text = "";
                _gameObjects[2].transform.GetChild(2).GetComponent<Text>().text = "";
                _gameObjects[3].transform.GetChild(2).GetComponent<Text>().text = "";
            }
            
        }

        public void SkillIcon()
        {
            
        }
    }
}