using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWorldBack : MonoBehaviour
{
    public Background bg;
    protected delegate Vector3 CorrectInstantiatePosition(Vector3 clickedPoint, Bounds bounds);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected GameObject InstantiateOnMousePos(GameObject prefab, CorrectInstantiatePosition fp)
    {
        GameObject _groundCell = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Bounds bounds = _groundCell.GetComponent<SpriteRenderer>().sprite.bounds;
        _groundCell.transform.localScale = new Vector3(bg.backgroundScale, bg.backgroundScale, 1);
        Vector2 mousePosition = Input.mousePosition; // Event.current.mousePosition;
        Vector3 pointOnWorldBack = Camera.main.ScreenToWorldPoint(new Vector3(
            mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
        _groundCell.transform.position = fp(pointOnWorldBack, bounds); // tilePosition;
        return _groundCell;
        //_groundCell.transform.parent = transform;
    }
    protected int SetSign(float point, float bound)
    {
        float t = point / bound * 2;
        if (t > 0) t += 0.5f;
        else t -= 0.5f;
        return (int)t;
    }
}
