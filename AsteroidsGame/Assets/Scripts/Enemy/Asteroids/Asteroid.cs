using UnityEngine;
using Game.Helper;

namespace Game.Enemy
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private AsteroidMovement _movement;
        [SerializeField] private AsteroidRotation _rotate;

        private enum Type : int
        {
            Big = 0,
            Medium = 2,
            Small = 4
        }

        [SerializeField] private Type _type;
        private string[] _asteroidsName = new string[] {"MedAsteroid", "MedAsteroid_2", "SmlAsteroid", "SmlAsteroid_2" };
        private Vector2 _direction;
        private float _spin;

        public void Parameters(Vector2 direct, Vector3 position)
        {
            transform.position = position;
            
            _direction = direct;
            _spin = Random.Range(-1, 2);
        }

        private void FixedUpdate()
        {
            _movement.GetMove(_direction, _rigidbody);

            _rotate.GetRotate(_spin, _rigidbody);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(tag))
            {
                if (_type != Type.Small)
                {
                    int t = (int)_type;
                    string newAsteroid = _asteroidsName[Random.Range(t, t + 2)];
                    var asteroid = ObjectPool.Instance.GetObject(newAsteroid);
                    if(asteroid != null) asteroid.GetComponent<Asteroid>().Parameters(Vector2.down, transform.position);
                }

                ObjectPool.Instance.DestroyObject(gameObject.name, gameObject);
            }
             
        }
    }
}
