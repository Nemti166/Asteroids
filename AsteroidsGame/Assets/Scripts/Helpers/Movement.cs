using UnityEngine;

namespace Game.Helper
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private Vector2 _accelSpeed;

        private float _saveSpeed;
        private Vector2 _saveVector;

        public Vector2 AccelSpeed => _accelSpeed;

        public void GetMove(bool velocity, Rigidbody2D rigidbody)
        {
            if (velocity)
            {
                _saveSpeed = _saveSpeed < _accelSpeed.y ? _saveSpeed + _accelSpeed.x : _accelSpeed.y;
                _saveVector = transform.right;
            }

            Move(_saveVector, _saveSpeed, rigidbody);
        }

        public void GetMove(Vector2 direction, float speed, Rigidbody2D rigidbody)
        {
            Move(direction, speed, rigidbody);
        }

        protected abstract void Move(Vector2 direction, float speed, Rigidbody2D rigidbody);
    }
}
