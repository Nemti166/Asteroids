using Game.Helper;
using UnityEngine;

namespace Game.Player
{
    public class RotationPlayer : Rotation
    {
        protected override void Rotate(float spin, float speed, Rigidbody2D rigidbody)
        {
            rigidbody.MoveRotation(rigidbody.rotation + -spin * speed * Time.fixedDeltaTime);
        }
    }
}
