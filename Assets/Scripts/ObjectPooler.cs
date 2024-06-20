using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour{
    public static ObjectPooler Instance { get; private set; }

    [System.Serializable]
    public class Pool {
        [HideInInspector]
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Fill();
        } 
        else {
            Destroy(gameObject);
        }
    }

    void Fill(){
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools) { 
            Queue<GameObject> objectQueue = new Queue<GameObject>();
            string tag = "";
            for(int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.parent = transform;
                //DontDestroyOnLoad(obj);
                tag = obj.name.Replace("(Clone)", "");
                obj.SetActive(false);
                objectQueue.Enqueue(obj);
            }
            poolDictionary.Add(tag, objectQueue);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {

        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");       
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);
 
        return objectToSpawn;
    }

    public void DeactivateAll() {
        for(int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

}
