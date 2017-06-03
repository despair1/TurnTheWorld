using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldBack : BasicWorldBack {
    //public Background bg;
    // Use this for initialization
    public GameObject playerPrefab;
    GameObject player;
    Bounds worldBounds;

    bool rotating = false;
    Quaternion rotationDirection;
    float rotationTime;
    Quaternion beginRotation;
    Quaternion endRotation;
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
        if (rotating) {
            rotationTime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(beginRotation, endRotation, rotationTime);
            if (rotationTime > 1)
            {
                EndRotaion();
            }
        }
        else
        {
            if (player && !player.GetComponent<Player>().isMoving)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    rotationDirection = Quaternion.FromToRotation(Vector3.up, Vector3.left);
                    BegingRotation();
                    //RotateLeft();
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    rotationDirection = Quaternion.FromToRotation(Vector3.up, Vector3.right);
                    BegingRotation();
                }
            }
        }
		
	}
    void EndRotaion()
    {
        rotating = false;
        player.transform.parent = null;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    void BegingRotation()
    {
        rotating = true;
        rotationTime = 0;
        beginRotation = transform.rotation;
        endRotation = transform.rotation * rotationDirection;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.transform.parent = transform;
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
