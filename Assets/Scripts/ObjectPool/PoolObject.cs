using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour {

    //prefab的UID
    private int key;

    public void SetUkey(int index)
    {
        key = index;
    }
    
    public virtual void Init()
    {
        Debug.Log("初始化本身資料");
      
    }

    protected void ReturnToPools()
    {
        Debug.Log("回傳到物件池");
        ObjectPoolManager.instance.Return(key, this.gameObject);
    }
}
