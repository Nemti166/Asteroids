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
            public string _name;
            public GameObject _model;
            public int _minimum;
        }

        [SerializeField] private List<Info> _infoList;
        private string _nameQueue = "AllAsteroids";

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

            GameObject empty = new GameObject();
            var allAsteroids = Instantiate(empty, transform, false);
            allAsteroids.name = _nameQueue;

            foreach (Info obj in _infoList)
            {
                _pools[obj._name + "(Clone)"] = new Queue<GameObject>();
                
                for (int i = 0; i < obj._minimum; i++)
                {
                    var go = NewObject(obj._name, allAsteroids.transform);
                    
                    _pools[obj._name + "(Clone)"].Enqueue(go);
                }
            }

            Destroy(empty);
        }

        private GameObject NewObject(string name, Transform parent)
        {
            GameObject obj = Instantiate(_infoList.Find(x => x._name == name)._model, parent);
            obj.SetActive(false);

            return obj;
        }

        public GameObject GetObject(string name)
        {
            if (!_pools.ContainsKey(name + "(Clone)"))
            {
                Debug.Log("No matches get");

                return null;
            }

            GameObject obj = _pools[name + "(Clone)"].Count > 0 ? _pools[name + "(Clone)"].Dequeue() : NewObject(name, transform);
            obj.SetActive(true);

            return obj;
        }

        public void DestroyObject(string name, GameObject obj)
        {
            if (!_pools.ContainsKey(name))
            {
                Debug.Log("No matches");

                return;
            }

            _pools[name].Enqueue(obj);
            obj.SetActive(false);
        }
    }
}