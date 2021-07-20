using System.Collections;
using UnityEngine;
using Game.Helper;

namespace Game.Enemy.UFO
{
    public class UFOControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private UFOMovement _movement;
        [SerializeField] private UFOWeapon _weapon;
        [SerializeField] private UFODamage _damage;
        [SerializeField] private UFOReset _reset;
        [SerializeField] private CheckBorder _checkBorder;

        private void Update()
        {
            if (!_checkBorder.OutBorder && _reset.CanMove)
                _weapon.StartFire();
        }

        private void FixedUpdate()
        {
            _movement.GetMove(Vector(), _movement.AccelSpeed.y, _rigidbody);

            _reset.CheckBorders(_checkBorder.OutBorder);
        }

        private Vector2 Vector()
        {
            if (_reset.CanMove && !_checkBorder.OutBorder)
                return _reset.Direct;
            else
                return Vector2.zero;
        }
    }
}
