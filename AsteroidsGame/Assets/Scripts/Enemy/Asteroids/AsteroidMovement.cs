using UnityEngine;
using Game.Helper;

namespace Game.Enemy
{
    public class AsteroidMovement : Movement
    {
        protected override void Move(Vector2 direction, float speed, Rigidbody2D rigidbody)
        {
            rigidbody.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }
}
