using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Helper
{
    public abstract class Rotation : MonoBehaviour
    {
        [SerializeField] private float _speedAngle;

        private float _angle;

        public void GetRotate()
        {


            Rotate(_angle);
        }

        protected abstract void Rotate(float angle);
    }
}
