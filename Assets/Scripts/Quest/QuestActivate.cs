using System;
using System.Collections.Generic;
using Controller;
using Interfaces.Stage;
using Stats;
using UI;
using UnityEngine;

namespace Quest
{
    public class QuestActivate : MonoBehaviour, IRegion
    {
        [SerializeField] private string _questDescription;
        private bool Spawned = false;
        private bool isActivate = false;
        private float _timer = 0f;
        private bool _finished = false;

        [SerializeField] private List<GameObject> _questSpawnObjects;
        [SerializeField] private List<GameObject> _questCheckObjects;

        private QuestUIController _questUIController;

        private void Awake()
        {
            _questCheckObjects = new List<GameObject>();
            _questUIController = FindObjectOfType<QuestUIController>();
        }

        private void Start()
        {
            FindObjectOfType<StageRegionController>().AddRegion(this);
        }

        private void Update()
        {
            if (isActivate)
            {
                CheckQuest();
            }

            if (_timer >= 4f)
            {
                isActivate = false;
                _questUIController.OffQuest();
                FindObjectOfType<StageRegionController>().FinishRegion(this);
                Destroy(gameObject);
            }
        }

        private void CheckQuest()
        {
            if (_questCheckObjects.Count == 0)
            {
                _finished = true;
                _timer += Time.deltaTime;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !Spawned)
            {
                isActivate = true;
                for (int i = 0; i < _questSpawnObjects.Count; i++)
                {
                    _questSpawnObjects[i].GetComponent<ObjectSpawner>().Spawn();
                    _questCheckObjects.Add(_questSpawnObjects[i].GetComponent<ObjectSpawner>().SpawnedObject);
                }

                Spawned = true;
                _questUIController.OnQuest(QuestString());
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<BasicStats>() != null)
                {
                    if (other.GetComponent<BasicStats>().Health <= 0)
                    {
                        _questCheckObjects.Remove(other.gameObject);
                        _questUIController.OnQuest(QuestString());
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.GetComponent<BasicStats>() != null)
                {
                    if (other.GetComponent<BasicStats>().Health > 1)
                    {
                        Debug.Log(other.GetComponent<BasicStats>().Health);
                        isActivate = false;
                        _questUIController.OffQuest();
                        for (int i = 0; i < _questCheckObjects.Count; i++)
                        {
                            Destroy(_questCheckObjects[i]);
                        }

                        _questCheckObjects.Clear();
                        Spawned = false;
                    }
                }
            }
        }

        private string QuestString()
        {
            return _questDescription + " " + (_questSpawnObjects.Count - _questCheckObjects.Count) + "/" +
                   _questSpawnObjects.Count;
        }
    }
}