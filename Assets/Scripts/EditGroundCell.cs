using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditGroundCell : MonoBehaviour, IWorldObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
        Debug.Log(" edit cell down ");
    }

    public string GetPrefabName()
    {
        return "ground_cell";
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
