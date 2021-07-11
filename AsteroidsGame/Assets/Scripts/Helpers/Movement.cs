using UnityEngine;

namespace Game.Helper
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _accel;

        private float _saveSpeed;
        private Vector2 _saveVector;

        public void GetMove(bool velocity, Rigidbody2D rigidbody)
        {
            if (velocity)
            {
                _saveSpeed = _saveSpeed < _maxSpeed ? _saveSpeed + _accel : _maxSpeed;
                _saveVector = transform.right;
            }

            Move(_saveVector, _saveSpeed, rigidbody);
        }

        protected abstract void Move(Vector2 direction, float speed, Rigidbody2D rigidbody);
    }
}
