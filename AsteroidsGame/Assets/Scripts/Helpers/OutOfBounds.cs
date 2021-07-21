using UnityEngine;

namespace Game.Helper
{
    public static class OutOfBounds
    {
        private static Camera _camera = Camera.main;

        private static int _axisOutOfGame;

        private static float _botBound;
        private static float _topBound;

        public static int AxisOutOfGame => _axisOutOfGame;


        public static float BottomBound()
        {
            var camHalfHeight = _camera.orthographicSize;
            var camPos = _camera.transform.position;
            
            _botBound = camPos.y - camHalfHeight;

            return _botBound;
        }

        public static float TopBound()
        {
            var camHalfHeight = _camera.orthographicSize;
            var camPos = _camera.transform.position;
            
            _topBound = camPos.y + camHalfHeight;

            return _topBound;
        }

        public static bool IsOutGameArea(Transform transform, float expansion, Bounds bounds)
        {
            var camHalfHeight = _camera.orthographicSize * expansion;
            var camHalfWidth = camHalfHeight * _camera.aspect * expansion;
            var camPos = _camera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = transform.position;

            if ((objectPos.x + bounds.extents.x > rightBound) || (objectPos.x - bounds.extents.x < leftBound))
            {
                _axisOutOfGame = 1;
                return true;
            }

            if ((objectPos.y - bounds.extents.y > topBound) || (objectPos.y + bounds.extents.y < bottomBound))
            {
                _axisOutOfGame = 2;
                return true;
            }

            _axisOutOfGame = 0;
            return false;
        }
    }
}
