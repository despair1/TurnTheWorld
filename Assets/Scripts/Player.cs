using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Vector3 lastPos;
    // Use this for initialization
    public bool isMoving = true;
	void Start () {
        lastPos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
        if (transform.position == lastPos) isMoving = false;
        else isMoving = true;
        lastPos = transform.position;
        //isMoving = true;
        
	}
}
