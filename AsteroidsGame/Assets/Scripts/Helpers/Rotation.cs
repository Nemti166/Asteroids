using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Helper
{
    public abstract class Rotation : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speedAngle;

        private float _spin;

        public void GetRotate(Vector2 direction)
        {
            _spin = Mathf.Atan2(direction.y, direction.x) * _speedAngle * Mathf.Rad2Deg;

            Rotate(_spin, _rigidbody);
        }

        protected abstract void Rotate(float spin, Rigidbody2D rigidbody);
    }
}
