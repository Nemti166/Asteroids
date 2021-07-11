using Game.Helper;
using UnityEngine;

namespace Game.Player
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        [SerializeField] private Controlling _control;
        [SerializeField] private MovementPlayer _movement;
        [SerializeField] private RotationPlayer _rotate;
        [SerializeField] private BulletPlayer _bullet;


        private void FixedUpdate()
        {
            _movement.GetMove(_control.Velocity(), _rigidbody);
            
            _rotate.GetRotate(_control.Rotation(), _rigidbody);
        }
    }
}
