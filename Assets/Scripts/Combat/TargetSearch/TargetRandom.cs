using System;
using ColliderScripts;
using Lightbug.CharacterControllerPro.Core;
using Stats;
using UnityEngine;
using Random = System.Random;

namespace Combat
{
    public class TargetRandom : MonoBehaviour
    {
        /*
         * Random a target in range
         */
        [SerializeField] private TargetCollider _targetCollider;

        private Random _rand = new Random();

        private GameObject _currentTarget;

        private void Start()
        {
            
        }

        private void Update()
        {
            if (_targetCollider.Targets.Count > 0)
            {
                if (_currentTarget == null)
                {
                    _currentTarget = _targetCollider.Targets[_rand.Next(0, _targetCollider.Targets.Count)];
                }else if (_currentTarget.GetComponent<BasicStats>().Health == 0)
                {
                    _targetCollider.Targets.Remove(_currentTarget);
                    if (_targetCollider.Targets.Count > 0)
                    {
                        _currentTarget = _targetCollider.Targets[_rand.Next(0, _targetCollider.Targets.Count)];
                    }
                }
            }
            else
            {
                _currentTarget = null;
            }
        }

        public GameObject CurrentTarget => _currentTarget;
    }
}