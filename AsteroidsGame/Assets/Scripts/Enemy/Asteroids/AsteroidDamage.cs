using Game.Helper;
using UnityEngine;

namespace Game.Enemy
{
    public class AsteroidDamage : MonoBehaviour
    {
        [SerializeField] private int _asteroidsCount;
        [SerializeField] private string[] _smallerAsteroids = new string[] { };

        private Vector2 _direction;

        public void DirectionAsteroid(Vector2 direct)
        {
            _direction = direct;
        }

        private void CreateSmallerAsteroids()
        {
            int changeDirection = 1;
            float speed = Random.Range(50, 100);
            string newAsteroidView = _smallerAsteroids[Random.Range(0, _smallerAsteroids.Length)];
            
            for (int i = 0; i < _asteroidsCount; i++)
            {
                changeDirection *= -1;
                Vector2 direction = new Vector2(_direction.x, _direction.y + Mathf.Sin(90) * changeDirection);

                GameObject asteroid = ObjectPool.Instance.GetObject(newAsteroidView);
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

                ObjectPool.Instance.DestroyObject(collision.gameObject.name, collision.gameObject);
                ObjectPool.Instance.DestroyObject(gameObject.name, gameObject);
            }
        }
    }
}
