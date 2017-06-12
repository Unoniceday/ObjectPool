using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour {

    public GameObject prefab;
    public GameObject prefab2;
	// Use this for initialization
	void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            ObjectPoolManager.instance.Get(prefab, transform.position, transform.rotation);

        }
        if (Input.GetMouseButtonDown(1))
        {
            ObjectPoolManager.instance.Get(prefab2, transform.position, transform.rotation);

        }
    }
}
