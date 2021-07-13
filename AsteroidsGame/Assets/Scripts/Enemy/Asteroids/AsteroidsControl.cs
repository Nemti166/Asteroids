using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class AsteroidsControl : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
        [SerializeField] private GameObject _asteroid;
        [SerializeField] private GameObject _mediumAsteroid;
        [SerializeField] private GameObject _smallAteroid;

        private List<GameObject> _activeBigAsteroids = new List<GameObject>();
        private List<GameObject> _activeMediumAsteroids = new List<GameObject>();

        private int _asteroidCount = 1;

        private void Start()
        {
            CreateBigAsteroid();
        }

        private void CreateBigAsteroid()
        {
            for (int i = 0; i < _asteroidCount; i++)
            {
                int index = Random.Range(0, _spawnPoints.Count);

                GameObject clone =
                Instantiate(_asteroid, _spawnPoints[index].transform.position, Quaternion.identity);

                _activeBigAsteroids.Add(clone);
            }
        }
    }
}
