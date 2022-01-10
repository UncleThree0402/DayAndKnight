using System;
using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using Stats;
using UnityEngine;

namespace ColliderScripts
{
    /*
     * Process target in range
     */
    public class TargetCollider : MonoBehaviour 
    {
        [SerializeField]
        private List<GameObject> _targets;

        private void Awake()
        {
            _targets = new List<GameObject>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<CharacterActor>() != null)
            {
                if (other.gameObject.GetComponent<BasicStats>().Health > 0)
                {
                    if (String.Compare(gameObject.transform.parent.tag, "Enemy") == 0)
                    {
                        if (String.Compare(other.gameObject.tag, "Enemy") != 0)
                        {
                            _targets.Add(other.gameObject);
                        }
                    }
                    else
                    {
                        if (String.Compare(other.gameObject.tag, "Enemy") == 0)
                        {
                            _targets.Add(other.gameObject);
                        }
                    }
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.GetComponent<CharacterActor>() != null)
            {
                if (other.gameObject.GetComponent<BasicStats>().Health == 0)
                {
                    if (String.Compare(gameObject.transform.parent.tag, "Enemy") == 0)
                    {
                        if (String.Compare(other.gameObject.tag, "Enemy") != 0)
                        {
                            _targets.Remove(other.gameObject);
                        }
                    }
                    else
                    {
                        if (String.Compare(other.gameObject.tag, "Enemy") == 0)
                        {
                            _targets.Remove(other.gameObject);
                        }
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<CharacterActor>() != null)
            {
                if (String.Compare(gameObject.tag, "Enemy") == 0)
                {
                    if (String.Compare(other.gameObject.tag, "Enemy") != 0)
                    {
                        _targets.Remove(other.gameObject);
                    }
                }
                else
                {
                    if (String.Compare(other.gameObject.tag, "Enemy") == 0)
                    {
                        _targets.Remove(other.gameObject);
                    }
                }
            }
        }

        public List<GameObject> Targets => _targets;
    }
}