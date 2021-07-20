using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Helper;

namespace Game.Enemy.UFO
{
    public class UFOReset : MonoBehaviour
    {
        private Vector3 _startPosition;
        private Vector2 _direct;
        private bool _move = false;

        public Vector2 Direct => _direct;
        public bool CanMove => _move;

        private void Start()
        {
            _startPosition = transform.position;

            NewStartPosition();

            StartCoroutine(MoveTimer());
        }

        private void NewStartPosition()
        {
            float bot = OutOfBounds.BottomBound() - OutOfBounds.BottomBound() * 0.2f;
            float top = OutOfBounds.TopBound() - OutOfBounds.TopBound() * 0.2f;
            float topBot = Random.Range(bot, top);
            float leftRight = Random.Range(0, 1f) > 0.5f ? 1 : -1;

            Vector3 newPosition = new Vector3(_startPosition.x * leftRight, topBot, _startPosition.z);
            DirectionVector(leftRight);

            transform.position = newPosition;
        }

        private IEnumerator MoveTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(16);

                _move = true;

                StopAllCoroutines();
            }
        }

        private void DirectionVector(float direct)
        {
            _direct = Vector2.right * direct;
        }

        public void CheckBorders(bool outBorder)
        {
            if(outBorder)
            {
                _move = false;

                NewStartPosition();

                StartCoroutine(MoveTimer());
            }
        }
    }
}
