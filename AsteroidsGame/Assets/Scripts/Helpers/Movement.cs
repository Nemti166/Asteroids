using UnityEngine;

namespace Game.Helper
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _accel;

        private float _saveSpeed;
        private Vector2 _saveDirection;

        public void GetMove(Vector2 direction)
        {


            Move(_saveSpeed, _saveDirection);
        }

        protected abstract void Move(float speed, Vector2 direction);
    }
}
