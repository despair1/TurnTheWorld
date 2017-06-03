using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataController : BasicDataControl {


    private void Awake()
    {
        scene_prefix = "game_";
        
    }
    // Use this for initialization
    void Start () {
        Invoke("SecondFrame", 0.0001f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void SecondFrame()
    {
        LoadWorld();
    }
}
