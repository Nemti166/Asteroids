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

        private bool _outBorder => _checkBorder.OutBorder;

        private void Update()
        {
            _weapon.CanFire(_reset.CanMove);
        }

        private void FixedUpdate()
        {
            _movement.GetMove(Vector(), _movement.AccelSpeed.y, _rigidbody);

            ResetUFO();
        }

        private void ResetUFO()
        {
            if (_damage.Damage || _outBorder)
            {
                _reset.ResetUFO();

                _damage.RefreshDamage();
            }
        }

        private Vector2 Vector()
        {
            if (_reset.CanMove)
                return _reset.Direct;
            else
                return Vector2.zero;
        }
    }
}
