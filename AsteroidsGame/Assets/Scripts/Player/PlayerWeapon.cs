using System.Collections;
using UnityEngine;
using Game.Helper;

namespace Game.Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private int _reload;

        private bool _readyFire = true;

        public void CreateShot()
        {
            if (!_readyFire) return;

            Fire();
        }

        private void Fire()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet = ObjectPool.Instance.GetObject("Bullet");
                bullet.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                StartCoroutine(Reload(_reload));
            }
        }

        private IEnumerator Reload(float cooldown)
        {
            _readyFire = false;
            
            yield return new WaitForSeconds(cooldown);

            _readyFire = true;

            StopAllCoroutines();
        }
    }
}
