using UnityEngine;

namespace Game.Enemy
{
    public class BigAsteroid : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private BigAsteroidMovement _movement;
        [SerializeField] private BigAsteroidRotation _rotate;
        [SerializeField] private GameObject _smallerAsteroid;

        private Vector2 _direction;
        private float _spin;

        private void Start()
        {
            float X = transform.position.x > 0 ? -1 : 1;
            float Y = transform.position.y > 0 ? -1 : 1;

            _spin = Random.Range(-5f, 5f);

            _direction = new Vector2(X, Y);
        }

        private void FixedUpdate()
        {
            _movement.GetMove(_direction, _rigidbody);

            _rotate.GetRotate(_spin, _rigidbody);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(tag))
            {
                CreateNewAsteroids();

                collision.gameObject.SetActive(false);
            }
        }

        private void CreateNewAsteroids()
        {
            for(int i = 0; i < 2; i++)
            {
                Instantiate(_smallerAsteroid, transform.position, Quaternion.identity);
            }
            
            gameObject.SetActive(false);
        }
    }
}
