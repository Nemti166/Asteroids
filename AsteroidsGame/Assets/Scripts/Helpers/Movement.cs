using UnityEngine;

namespace Game.Helper
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _accel;

        private float _currentSpeed;
        private float _saveSpeed;
        private Vector2 _saveDirection;

        public void GetMove(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                _saveDirection = direction;

                _currentSpeed = _currentSpeed >= _maxSpeed ? _maxSpeed : _currentSpeed + _accel * Time.deltaTime;

                _saveSpeed = _currentSpeed;
            }
            else
            {
                _currentSpeed = _currentSpeed <= 0 ? 0 : _currentSpeed - _accel * Time.deltaTime;
            }

            Move(_saveSpeed, _saveDirection);
        }

        protected abstract void Move(float speed, Vector2 direction);
    }
}
