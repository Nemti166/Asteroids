using System.Collections.Generic;
using UnityEngine;
using Game.Helper;

namespace Game.Enemy
{
    public class AsteroidsControl : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

        private int _asteroidCount = 2;

        private void Start()
        {
            CreateBigAsteroid();
        }

        private void CreateBigAsteroid()
        {
            for (int i = 0; i < _asteroidCount; i++)
            {
                int index = Random.Range(0, _spawnPoints.Count);

                var asteroid = ObjectPool.Instance.GetObject("BigAsteroid");
                if(asteroid != null) asteroid.GetComponent<Asteroid>().Parameters(Vector2.one, _spawnPoints[index].position);
            }
        }
    }
}
