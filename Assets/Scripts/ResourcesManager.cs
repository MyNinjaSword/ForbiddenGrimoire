using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    public Button frogButton;
    public Button leavesButton;
    public AlchamyManager alchamyManager;
    public TimeManager timeManager;

    public bool collectedBoth = false;
    public bool collectedFrog = false;
    public bool collectedLeaves = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnButtonPress(int id)
    {
        if (id == 0)
        {
            collectedFrog = true;
            frogButton.GetComponent<Image>().color = Color.green;
        }
        else if (id == 1)
        {
            collectedLeaves = true;
            leavesButton.GetComponent<Image>().color = Color.green;
        }

        if(collectedFrog && collectedLeaves && id == 2) 
        { 
            collectedBoth = true;
            alchamyManager.StartUp();
            this.gameObject.SetActive(false);
        }

        if(id == 2)
        {
            alchamyManager.StartUp();
            this.gameObject.SetActive(false);
        }

        timeManager.ReduceTime();
    }
}
