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
        if (Input.GetKeyDown(KeyCode.F9))
        {
            LoadWorld();
            Debug.Log("f9 down ");
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
    public void LoadWorld()
    {
        string json_world = System.IO.File.ReadAllText("world_json.txt");
        WorldObjects wos = JsonUtility.FromJson<WorldObjects>(json_world);
        foreach ( IWorldObject wo in wb.GetComponentsInChildren<IWorldObject>())
        {
            Destroy(wo.GetTransform().gameObject);
        }
        GameObject groundCellPrefab = Resources.Load<GameObject>("Prefabs/ground_cell");
        foreach ( WorldObject wo in wos.worldObjects)
        {
            GameObject go = Instantiate<GameObject>(groundCellPrefab);
            go.transform.position = wo.position;
            go.transform.rotation = wo.rotation;
            go.transform.localScale = new Vector3(wb.bg.backgroundScale,
                 wb.bg.backgroundScale, 1);
            go.transform.parent = wb.transform;


        }
    }
}
