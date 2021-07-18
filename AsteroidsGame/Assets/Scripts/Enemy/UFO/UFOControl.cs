using UnityEngine;
using Game.Helper;

namespace Game.Enemy.UFO
{
    public class UFOControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private UFOMovement _movement;
        [SerializeField] private UFOBullet _weapon;
        [SerializeField] private UFODamage _damage;
    }
}
