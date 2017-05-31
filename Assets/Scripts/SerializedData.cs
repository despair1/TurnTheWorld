using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldObject
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
}

[System.Serializable]
public class WorldObjects
{
    public List<WorldObject> worldObjects = new List<WorldObject>();
}