using System.Collections.Generic;
using System;
using UnityEngine;

namespace Game.Helper
{
    public class ObjectPool : MonoBehaviour
    {
        [Serializable]
        public struct Info
        {
            public enum Queue
            {
                BigAsteroid,
                MediumAsteroid,
                SmallAsteroid,
                Bullet
            };
            public string _name;
            public GameObject _model;
            public int _minimum;
            public Queue _queue;
        }

        [SerializeField] private List<Info> _infoList;
        
        private Dictionary<Info.Queue, Queue<GameObject>> _pools;

        #region Singlton
        public static ObjectPool Instance;

        private void Awake()
        {
            if (Instance == null) Instance = this;

            Init();
        }
        #endregion

        private void Init()
        {
            _pools = new Dictionary<Info.Queue, Queue<GameObject>>();

            foreach (Info obj in _infoList)
            {
                _pools[obj._queue] = new Queue<GameObject>();

                for (int i = 0; i < obj._minimum; i++)
                {
                    var go = NewObject(obj._queue);

                    _pools[obj._queue].Enqueue(go);
                }
            }
        }

        private GameObject NewObject(Info.Queue queue)
        {
            GameObject obj = Instantiate(_infoList.Find(x => x._queue == queue)._model);
            obj.SetActive(false);

            return obj;
        }

        public GameObject GetObject(Info.Queue queue)
        {
            GameObject obj = _pools[queue].Count > 0 ? _pools[queue].Dequeue() : NewObject(queue);
            obj.SetActive(true);

            return obj;
        }

        public void DestroyObject(GameObject obj)
        {
            _pools[obj.GetComponent<IObjectType>().Type].Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
