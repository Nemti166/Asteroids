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
                Asteroid = 0,
                Bullet = 1
            };

            public string _name;
            public GameObject _model;
            public int _minimum;
            public Queue _queue;
        }

        [SerializeField] private List<Info> _infoList;
        
        //Добавление чтобы находить по имени GameObject+(Clone)
        private string _crutch = "(Clone)";

        private Dictionary<string, Queue<GameObject>> _pools;

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
            _pools = new Dictionary<string, Queue<GameObject>>();
            
            foreach (Info obj in _infoList)
            {
                string crutch = obj._name + _crutch;

                _pools[crutch] = new Queue<GameObject>();

                for (int i = 0; i < obj._minimum; i++)
                {
                    var go = NewObject(obj._name);

                    _pools[crutch].Enqueue(go);
                }
            }
        }

        private GameObject NewObject(string name)
        {
            GameObject obj = Instantiate(_infoList.Find(x => x._name == name)._model);
            obj.SetActive(false);

            return obj;
        }

        public GameObject GetObject(string name)
        {
            string crutch = name + _crutch;

            GameObject obj = _pools[crutch].Count > 0 ? _pools[crutch].Dequeue() : NewObject(name);
            obj.SetActive(true);

            return obj;
        }

        public void DestroyObject(string name, GameObject obj)
        {
            if (!_pools.ContainsKey(name)) return;

            _pools[name].Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
