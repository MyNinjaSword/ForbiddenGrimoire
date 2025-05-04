using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour
{
    private GameObject selectedObject;
    Vector2 offset;
    public Camera Cam;
    private Vector3 oldMousePosition;

    private bool isSelected;

    public bool isBark;
    public AlchamyManager alchamyManager;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 mousePosition = (Vector2)Cam.ViewportToWorldPoint(Cam.ScreenToViewportPoint(Input.mousePosition));


        if (isSelected )
        {
            transform.position = (Vector2)Cam.ViewportToWorldPoint(Cam.ScreenToViewportPoint(Input.mousePosition));
        }
    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

    private void OnMouseUp()
    {
        isSelected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bowl")
        {
            this.gameObject.SetActive(false);
            alchamyManager.ObjectAdded(isBark);
        }
    }

}
