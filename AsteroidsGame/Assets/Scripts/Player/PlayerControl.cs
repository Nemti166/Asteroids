using Game.Helper;
using UnityEngine;

namespace Game.Player
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private Controlling _control;
        [SerializeField] private MovementPlayer _movement;
        [SerializeField] private RotationPlayer _rotate;
        [SerializeField] private BulletPlayer _bullet;


        private void FixedUpdate()
        {
            _movement.GetMove(_control.Direction());
            
            _rotate.GetRotate();
        }
    }
}
