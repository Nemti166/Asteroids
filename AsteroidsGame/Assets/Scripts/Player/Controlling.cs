using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class Controlling : MonoBehaviour
    {
        Vector2 _dir = Vector2.zero;

       public Vector2 Direction()
        {
            _dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            return _dir;
        }
    }
}
