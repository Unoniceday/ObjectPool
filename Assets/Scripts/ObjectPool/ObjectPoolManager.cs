using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {
    

    public static ObjectPoolManager instance = null;
   
    private static Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
    }

    
    public GameObject Get(GameObject prefab,Vector3 position,Quaternion rotation)
    {
        int key = prefab.GetInstanceID();
      
        GameObject o;

        if (pool.ContainsKey(key) && pool[key].Count > 0)
        {
            Queue<GameObject> list = pool[key];
            o = list.Dequeue();
           
            //重新初始化相關狀態
            o.SetActive(true);
            o.transform.position = position;
            o.transform.rotation = rotation;
            

        }
        else
        {
            o = Instantiate(prefab, position, rotation);
            o.transform.SetParent(transform);
        }

        //在這裡調用物件的初始化
        o.GetComponent<PoolObject>().Init();
        o.GetComponent<PoolObject>().SetUkey(key);
      

        return o;
    }

    public GameObject Return(int p_key,GameObject o)
    {
        Debug.Log("Return Key" + p_key);
        if (pool.ContainsKey(p_key))
        {
            Queue<GameObject> list = pool[p_key];
            list.Enqueue(o);
        }
        else
        {
            pool.Add(p_key, new Queue<GameObject>());
            pool[p_key].Enqueue(o);
        }

        o.SetActive(false);
       
        return o; 
    }
	
}
