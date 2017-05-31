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
        Bounds bounds = _groundCell.GetComponent<SpriteRenderer>().sprite.bounds;
        _groundCell.transform.localScale=new Vector3(bg.backgroundScale, bg.backgroundScale, 1);
        Vector2 mousePosition = Input.mousePosition; // Event.current.mousePosition;
        Vector3 pointOnWorldBack = Camera.main.ScreenToWorldPoint(new Vector3(
            mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
        /*Vector3 tilePosition = new Vector3(
            ((int)(cellPosition[0] / bounds.size.x*2+0.5)) * bounds.size.x/2,
            ((int)(cellPosition[1] / bounds.size.y*2+0.5)) * bounds.size.y/2,
            cellPosition[2]);
        */
        _groundCell.transform.position = GetTilePosition(pointOnWorldBack, bounds); // tilePosition;
        Debug.Log("on mouse down");

    }
    private Vector3 GetTilePosition(Vector3 pointOnWorldBack, Bounds bounds)
    {
        return new Vector3(
            SetSign(pointOnWorldBack[0], bounds.size.x) * bounds.size.x / 2,
            SetSign(pointOnWorldBack[1], bounds.size.y) * bounds.size.y / 2,
            -1f); // pointOnWorldBack[2]);
        
    }
    private int SetSign(float point,float bound)
    {
        float t = point / bound * 2;
        if (t > 0) t += 0.5f;
        else t -= 0.5f;
        return (int)t;
    }
}
