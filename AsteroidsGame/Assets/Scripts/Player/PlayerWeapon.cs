using System.Collections;
using UnityEngine;

namespace Game.Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _weapon;
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
                Instantiate(_weapon, transform.position, transform.rotation);
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
