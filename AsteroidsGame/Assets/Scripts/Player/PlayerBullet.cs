using Game.Helper;
using UnityEngine;


namespace Game.Player
{
    public class PlayerBullet : Bullet
    {
        protected override void MoveBullet(Vector2 direction, float speed, Rigidbody2D rigidbody)
        {
            rigidbody.velocity = direction * speed;
        }
    }
}
