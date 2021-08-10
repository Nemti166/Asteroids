using System.Collections.Generic;
using UnityEngine;
using Game.Helper;

namespace Game.Enemy
{
    public class AsteroidsControl : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
        [SerializeField] private ObjectPool.Info.Queue _type;

        private int _asteroidCount = 2;

        private void Update()
        {
            AsteroidCheck();
        }

        private void CreateBigAsteroid()
        {
            float X = Random.Range(-1f, 1f);
            float Y = Random.Range(-1f, 1f);

            Vector2 direction = new Vector2(X, Y);

            for (int i = 0; i < _asteroidCount; i++)
            {
                int index = Random.Range(0, _spawnPoints.Count);
                GameObject asteroid = ObjectPool.Instance.GetObject(_type);
                
                asteroid.GetComponent<Asteroid>().Parameters(direction, 0, _spawnPoints[index].position);
            }

            _asteroidCount += 1;
        }

        private void AsteroidCheck()
        {
            var chek = GameObject.FindGameObjectWithTag("Asteroid");

            if (chek == null) CreateBigAsteroid();
        }
    }
}
