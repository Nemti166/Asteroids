using Game.Helper;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.CompareTag(tag))
            {
                ObjectPool.Instance.DestroyObject(gameObject.name, gameObject);
            }
        }

        protected abstract void MoveBullet(Vector2 direction, float speed, Rigidbody2D rigidbody);
    }
}
