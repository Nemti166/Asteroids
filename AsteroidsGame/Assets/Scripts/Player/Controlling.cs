using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class Controlling : MonoBehaviour
    {
        private Vector2 _dir = Vector2.zero;
        
       private Vector2 _rot = Vector2.zero;

       public Vector2 Direction()
        {
            _dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            return _dir;
        }

        public Vector2 Rotation()
        {
            _rot = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            return _rot;
        }
    }
}
