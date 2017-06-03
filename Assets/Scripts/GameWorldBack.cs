using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldBack : BasicWorldBack {
    //public Background bg;
    // Use this for initialization
    public GameObject playerPrefab;
    GameObject player;
    Bounds worldBounds;
    void Start () {
        transform.localScale = new Vector3(bg.backgroundScale, bg.backgroundScale, 1);
        worldBounds = this.gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
    }
	
	// Update is called once per frame
	void Update () {
        if (!player & Input.GetMouseButtonDown(0))
        {
            Debug.Log("Creating player");
            CreatePlayer();
        }

		
	}
    void CreatePlayer()
    {
        player = InstantiateOnMousePos(playerPrefab, CorrectPlayerPos);

    }
    Vector3 CorrectPlayerPos(Vector3 clickedPoint, Bounds bounds)
    {
        Vector3 corected = new Vector3(clickedPoint[0], clickedPoint[1], clickedPoint[2]);
        if (clickedPoint[1] < worldBounds.size.y / 3.5)
        {
            corected[1] = worldBounds.size.y / 3.5f;
            //return new Vector3(clickedPoint[0], , clickedPoint[2]);
        }
        corected[0]=SetSign(clickedPoint[0],worldBounds.size.x/9)* worldBounds.size.x/18;
        return corected;
    }
}
