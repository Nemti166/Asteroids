using UnityEngine;

namespace Game.Helper
{
    public class CheckBorder : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _representation;

        private bool _outBorder = false;

        public bool OutBorder => _outBorder;

        private enum Axis
        {
            X = 1,
            Y = 2
        }

        void FixedUpdate()
        {
            CheckBorders();
        }

        private void CheckBorders()
        {
            float posX = transform.position.x;
            float posY = transform.position.y;

            _outBorder = false;

            if(OutOfBounds.IsOutGameArea(transform, _representation.bounds))
            {
                if (OutOfBounds.AxisOutOfGame == (int)Axis.X)
                    posX = -posX * 0.9f;
                if (OutOfBounds.AxisOutOfGame == (int)Axis.Y)
                    posY = -posY * 0.9f;

                _outBorder = true;

                transform.position = new Vector3(posX, posY, transform.position.z);
            }
        }
    }
}
