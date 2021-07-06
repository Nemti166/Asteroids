using UnityEngine;

namespace Game.Helper
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _accel;

        private float _saveSpeed;
        private Vector2 _saveDirection;

        public void GetMove(Vector2 direction)
        {
            _saveSpeed = _saveSpeed < _maxSpeed ? _saveSpeed + _accel * Time.deltaTime : _maxSpeed;

            _saveDirection = direction == Vector2.zero ? _saveDirection : direction;

            Move(_saveSpeed, _saveDirection, _rigidbody);
        }

        protected abstract void Move(float speed, Vector2 direction, Rigidbody2D rigidbody);
    }
}
