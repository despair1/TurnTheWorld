using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {
    public WorldBack wb;
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
		
	}
    public void SaveWorld()
    {
        var backObjects = wb.GetComponentsInChildren<IWorldObject>();
        WorldObjects wos = new WorldObjects();
        
        foreach (IWorldObject worldObject in backObjects)
        {
            WorldObject wo = new WorldObject();
            wo.name = worldObject.GetPrefabName();
            wo.position = worldObject.GetTransform().position;
            wo.rotation = worldObject.GetTransform().rotation;
            wos.worldObjects.Add(wo);

        }
        string json = JsonUtility.ToJson(wos, true);
        System.IO.File.WriteAllText("world_json.txt", json);
    }
}
