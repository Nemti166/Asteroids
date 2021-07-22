using System.Collections;
using UnityEngine;
using Game.Helper;

namespace Game.Enemy.UFO {
    public class UFOWeapon : MonoBehaviour
    {
        [SerializeField] private int _reload;
        [SerializeField] private Transform _target;

        private bool _cantFire = false;

        private void Start()
        {
            StartCoroutine(Reload(_reload));
        }

        public void CanFire(bool fire)
        {
            _cantFire = fire;
        }

        private void Fire()
        {
            if (_cantFire)
            {
                GameObject bullet = ObjectPool.Instance.GetObject("Bullet");
                bullet.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = RotationBullet();
                bullet.tag = "Enemy";

            }
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
            while (true)
            {
                yield return new WaitForSeconds(reload);

                Fire();
            }
        }
    }
}
