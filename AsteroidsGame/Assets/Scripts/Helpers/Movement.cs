using UnityEngine;

namespace Game.Helper
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _accel;

        private float cur;
        private float oldSpeed;
        private Vector2 oldDirection;

        public void GetMove(Vector2 direction)
        {
            if(direction != Vector2.zero)
            {
                oldDirection = direction;
                
                cur = cur >= _maxSpeed ? _maxSpeed : cur + _accel * Time.deltaTime;

                oldSpeed = cur;
            }
            else
            {
                cur = 0;
            }

            Debug.Log(cur);

            Move(oldSpeed, oldDirection);
        }

        protected abstract void Move(float speed, Vector2 direction);
    }
}
