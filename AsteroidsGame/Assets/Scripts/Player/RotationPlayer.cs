using Game.Helper;
using UnityEngine;

namespace Game.Player
{
    public class RotationPlayer : Rotation
    {
        protected override void Rotate(float angle, float directition, Rigidbody2D rigidbody)
        {
            rigidbody.MoveRotation(angle * directition);
        }
    }
}
