using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    private GameObject mixer;
    public GameObject HandleLogic;
    public Vector2 rightLocation;
    public Vector2 leftLocation;
    public Vector3 leftRotation;
    public Vector3 rightRotation;
    private bool isSelected;
    private Camera Cam;

    private RectTransform mixerTransform;

    private int handleTurns;

    public AlchamyManager alchMan;


    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        mixer = this.gameObject;
        mixerTransform = mixer.GetComponent<RectTransform>();
        mixerTransform.anchoredPosition = rightLocation;
        mixerTransform.localEulerAngles = rightRotation;
    }


    public void MoveHandle(float value)
    {
        float xLerp = Mathf.Lerp(leftLocation.x, rightLocation.x, value);

        mixerTransform.anchoredPosition = new Vector2 (xLerp, mixerTransform.anchoredPosition.y);

        float zRot = Mathf.Lerp(leftRotation.z, rightRotation.z, value);

        mixerTransform.localEulerAngles = new Vector3 (0, 0, zRot);

        if(handleTurns % 2 == 0)
        {
            if(value < 0.2f)
            {
                handleTurns++;
            }
        }
        else
        {
            if(value> 0.8f)
            {
                handleTurns++;
            }
        }

        if(handleTurns >= 2)
        {
            handleTurns = 0;
            alchMan.MixingFinished();
        }
    }
}
