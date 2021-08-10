using Game.Helper;
using UnityEngine;

namespace Game.Enemy
{
    public class AsteroidDamage : MonoBehaviour
    {
        [SerializeField] private int _asteroidsCount;
        [SerializeField] private GameObject[] _smallerAsteroids = new GameObject[] { };

        private Vector2 _direction;

        public void DirectionAsteroid(Vector2 direct)
        {
            _direction = direct;
        }

        private void CreateSmallerAsteroids()
        {
            float speed = Random.Range(50, 100);
            GameObject newAsteroidView = _smallerAsteroids[Random.Range(0, _smallerAsteroids.Length)];
            
            for (int i = 0; i < _asteroidsCount; i++)
            {
                Vector2 direction = new Vector2(_direction.x, _direction.y);

                GameObject asteroid = ObjectPool.Instance.
                    GetObject(newAsteroidView.GetComponent<IObjectType>().Type);

                asteroid.GetComponent<Asteroid>().Parameters(direction, speed, transform.position);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(tag))
            {
                if (_smallerAsteroids.Length != 0)
                {
                    CreateSmallerAsteroids();
                }

                ObjectPool.Instance.DestroyObject(gameObject);
            }
        }
    }
}
