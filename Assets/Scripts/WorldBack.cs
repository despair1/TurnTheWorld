using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBack : MonoBehaviour {
    public Background bg;
    public GameObject groundCell;
	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(bg.backgroundScale, bg.backgroundScale, 1);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GameObject _groundCell = Instantiate(groundCell , new Vector3(0, 0, 0), Quaternion.identity);
        _groundCell.transform.localScale=new Vector3(bg.backgroundScale, bg.backgroundScale, 1);
        Debug.Log("on mouse down");

    }
}
