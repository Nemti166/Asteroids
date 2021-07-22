
using UnityEngine;

namespace Game.Enemy.UFO
{
    public class UFODamage : MonoBehaviour
    {
        private bool _damage = false;

        public bool Damage => _damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(tag))
            {
                _damage = true;
            }
        }

       public void RefreshDamage()
        {
            _damage = false;
        }
    }
}
