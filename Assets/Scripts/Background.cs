using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    SpriteRenderer sr;
    // Use this for initialization
    public float backgroundScale;
	void Awake () {
        sr = this.GetComponent<SpriteRenderer>();
        float spriteHeight = sr.sprite.bounds.size.y;
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        backgroundScale = worldScreenHeight / spriteHeight;
        transform.localScale = new Vector3(backgroundScale, backgroundScale, 1);
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
