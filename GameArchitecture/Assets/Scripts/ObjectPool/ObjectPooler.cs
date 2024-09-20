using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool 
{ 
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class pool
        {
            public string tag;
            public GameObject prefab;
            public int amount;
        }

        public List<pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

        private void Start()
        {
            foreach (var pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.amount; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag)) return null;

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPoolObject poolObj = objectToSpawn.GetComponent<IPoolObject>();
            if(poolObj != null)
            {
                poolObj.OnObjectSpawned();
            }

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}
