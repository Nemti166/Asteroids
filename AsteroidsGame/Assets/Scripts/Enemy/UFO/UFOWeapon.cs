using System.Collections;
using UnityEngine;
using Game.Helper;

namespace Game.Enemy.UFO {
    public class UFOWeapon : MonoBehaviour
    {
        [SerializeField] private int _reload;
        [SerializeField] private Transform _target;

        private bool _activeReload = false;

        public void StartFire()
        {
           
            if (!_activeReload)
                StartCoroutine(Reload(_reload));
        }

        public void StopFire()
        {
            StopAllCoroutines();
        }

        private void Fire()
        {
            GameObject bullet = ObjectPool.Instance.GetObject("Bullet");
            bullet.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = RotationBullet();
            bullet.tag = "Enemy";

            _activeReload = false;
        }

        private Quaternion RotationBullet()
        {
            Vector2 direct = _target.position - transform.position;
            float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            return rotation;
        }

        private IEnumerator Reload(float reload)
        {
            _activeReload = true;
            Debug.Log(_activeReload);
            while (true)
            {
                yield return new WaitForSeconds(reload);

                Fire();
            }
        }
    }
}
