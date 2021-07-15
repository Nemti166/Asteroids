using UnityEngine;
using Game.Helper;

namespace Game.Enemy
{
    public class AsteroidRotation : Rotation
    {
        protected override void Rotate(float spin, float speed, Rigidbody2D rigidbody)
        {
            rigidbody.MoveRotation(rigidbody.rotation + -spin * speed * Time.fixedDeltaTime);
        }
    }
}
