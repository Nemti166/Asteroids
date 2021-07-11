using Game.Helper;
using UnityEngine;

namespace Game.Player {
    public class MovementPlayer : Movement
    {
        protected override void Move(Vector2 direction, float speed, Rigidbody2D rigidbody)
        {
            rigidbody.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }
}
