using System.Collections;
using UnityEngine;
using Game.Helper;

namespace Game.Player
{
    public class PlayerDamage : MonoBehaviour
    {
        private bool _invincible = false;

        private void Start()
        {
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            StartCoroutine(InvincibleTime());

            while (true)
            {
                yield return new WaitForSeconds(3f);

                AlphaNormalize();

                StopAllCoroutines();
            }
        }

        private IEnumerator InvincibleTime()
        {
            while (true)
            {
                _invincible = true;

                AlphaChange();

                yield return new WaitForSeconds(0.2f);
            }
        }

        private void AlphaNormalize()
        {
            _invincible = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

        private void AlphaChange()
        {
            float alpha = gameObject.GetComponent<SpriteRenderer>().color.a;

            alpha = alpha > 0 ? alpha - 1f : alpha + 1f;

            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(tag))
            {
                ObjectPool.Instance.DestroyObject(collision.gameObject.name, collision.gameObject);

                if (!_invincible)
                {
                    StartCoroutine(Timer());
                }
            }
        }
    }
}
