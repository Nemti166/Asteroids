using UnityEngine;

namespace Game.Helper
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;

        private void FixedUpdate()
        {
            MoveBullet(transform.right, _speed, _rigidbody);
        }

        protected abstract void MoveBullet(Vector2 direction, float speed, Rigidbody2D rigidbody);
    }
}
