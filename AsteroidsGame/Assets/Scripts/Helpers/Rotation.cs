using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Helper
{
    public abstract class Rotation : MonoBehaviour
    {
        [SerializeField] private float _speedAngle;

        public void GetRotate(float spin, Rigidbody2D rigidbody)
        {
            Rotate(spin, _speedAngle, rigidbody);  
        }

        protected abstract void Rotate(float spin, float speed, Rigidbody2D rigidbody);
    }
}
