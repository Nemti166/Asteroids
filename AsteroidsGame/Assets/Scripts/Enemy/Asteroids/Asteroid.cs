using UnityEngine;
using Game.Helper;

namespace Game.Enemy
{
    public class Asteroid : MonoBehaviour, IObjectType
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private AsteroidMovement _movement;
        [SerializeField] private AsteroidRotation _rotate;
        [SerializeField] private AsteroidDamage _damage;

        [SerializeField] private ObjectPool.Info.Queue type;

        private Vector2 _direction;
        private float _spin;
        private float _speed;

        public ObjectPool.Info.Queue Type => type;

        public void Parameters(Vector2 direct, float speed, Vector3 position)
        {
            transform.position = position;
           
            _direction = direct;
            _damage.DirectionAsteroid(_direction);

            _speed = _speed == 0 ? Random.Range(_movement.AccelSpeed.x, _movement.AccelSpeed.y) : speed;

            _spin = Random.Range(-1, 2);
        }

        private void FixedUpdate()
        {
            _movement.GetMove(_direction, _speed, _rigidbody);

            _rotate.GetRotate(_spin, _rigidbody);
        }
    }
}
