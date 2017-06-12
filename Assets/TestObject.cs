using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : PoolObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Init()
    {
        StartCoroutine(WaitDestory());
    }

    IEnumerator WaitDestory()
    {
        yield return new WaitForSeconds(2f);
        ReturnToPools();
    }

   
}
