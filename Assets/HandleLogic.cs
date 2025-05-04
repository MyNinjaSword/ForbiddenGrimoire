using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLogic : MonoBehaviour
{
    public Camera Cam;
    private bool isSelected;

    private float upperBound = 895;
    private float lowerBound = -831;

    public float currentPos;

    public Mixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 mousePosition = (Vector2)Cam.ViewportToWorldPoint(Cam.ScreenToViewportPoint(Input.mousePosition));
        Vector2 newPostion = new Vector2(mousePosition.x, transform.position.y);

        if (newPostion.x > 895)
        {
            return;
        }
        else if(newPostion.x < - 831)
        {
            return;
        }

        if (isSelected)
        {
            transform.position = new Vector2 (mousePosition.x, transform.position.y);
        }

        currentPos = (transform.position.x) / (upperBound - lowerBound);
        currentPos += 0.5f;
        mixer.MoveHandle(currentPos);
    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

    private void OnMouseUp()
    {
        isSelected = false;
    }
}
