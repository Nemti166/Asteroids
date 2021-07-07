using Game.Helper;
using UnityEngine;

namespace Game.Player
{
    public class RotationPlayer : Rotation
    {
        protected override void Rotate(float spin, Rigidbody2D rigidbody)
        {
            rigidbody.MoveRotation(spin);
            
        }
    }
}
