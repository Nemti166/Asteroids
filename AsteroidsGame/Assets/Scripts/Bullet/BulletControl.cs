using Game.Helper;
using UnityEngine;

namespace Game.Helper
{
    public class BulletControl : Bullet
    {
        protected override void MoveBullet(Vector2 direction, float speed, Rigidbody2D rigidbody)
        {
            rigidbody.velocity = direction * speed;
        }
    }
}
