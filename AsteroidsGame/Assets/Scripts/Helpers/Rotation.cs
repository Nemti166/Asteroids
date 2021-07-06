using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Helper
{
    public abstract class Rotation : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private float _speedAngle;

        private float _angle;
        private float _directionAngle;

        public void GetRotate(Vector2 direction)
        {
            _angle += _speedAngle * Time.deltaTime;

            _directionAngle = Mathf.Atan2(direction.y, direction.x);

            Rotate(_angle, _directionAngle, rigidbody);
        }

        protected abstract void Rotate(float angle, float _directionAngle, Rigidbody2D rigidbody);
    }
}
