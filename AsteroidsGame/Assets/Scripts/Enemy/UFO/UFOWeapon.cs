using System.Collections;
using UnityEngine;
using Game.Helper;

namespace Game.Enemy.UFO {
    public class UFOWeapon : MonoBehaviour
    {
        [SerializeField] private int _reload;

        private bool _activeCooldown = false;

        public void StartFire()
        {
            if (!_activeCooldown)
                StartCoroutine(Reload(_reload));
        }

        private void Fire()
        {
            GameObject bullet = ObjectPool.Instance.GetObject("Bullet");
            bullet.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            _activeCooldown = false;
            StartCoroutine(Reload(_reload));
        }

        private IEnumerator Reload(float cooldown)
        {
            _activeCooldown = true;

            while (true)
            {
                yield return new WaitForSeconds(cooldown);

                Fire();
            }
        }
    }
}
