using UnityEngine;

namespace Quest
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        private GameObject _spawnedObject;

        public void Spawn()
        {
            _spawnedObject = Instantiate(_gameObject, transform.position, Quaternion.identity);
            _spawnedObject.transform.parent = transform.parent;
        }

        public GameObject SpawnedObject => _spawnedObject;
    }
}