using Game.Helper;
using UnityEngine;

namespace Game.Player {
    public class MovementPlayer : Movement
    {
        protected override void Move(float speed, Vector2 direction, Rigidbody2D rigidbody)
        {
            rigidbody.velocity = speed * direction;
        }
    }
}
