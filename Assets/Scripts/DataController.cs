using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : BasicDataControl {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveWorld();
            Debug.Log("f5 pressed");
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            LoadWorld();
            Debug.Log("f9 down ");
        }
		
	}
    protected override void PreLoadWorld()
    {
        foreach (IWorldObject wo in wb.GetComponentsInChildren<IWorldObject>())
        {
            Destroy(wo.GetTransform().gameObject);
        }
    }

}
