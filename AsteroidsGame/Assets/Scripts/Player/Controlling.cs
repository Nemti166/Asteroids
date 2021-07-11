using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class Controlling : MonoBehaviour
    {
       public bool Velocity()
        {
            float _dir = Input.GetAxisRaw("Vertical");

            return _dir > 0;
        }

        public float Rotation()
        {
            float rotate = Input.GetAxis("Horizontal");

            return rotate;
        }
    }
}
