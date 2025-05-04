using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchamyManager : MonoBehaviour
{
    public GameObject leavesParent;
    public GameObject[] leaves = new GameObject[8];
    public GameObject barkParent;
    public GameObject[] bark = new GameObject[3];
    public int leavesAdded = 0;
    public int barkAdded = 0;   
    public Mixer mixer;
    public GameObject bowl;
    public HandleLogic handle;

    public GameObject endButton;

    private int alchemyStage = 0; //0 is adding leaves, 1 is mixing leaves, 2 is adding tree bark, 3 is mixing bark, 4 then button to finish

    public DialogueManager dialogueManager;
    public ResourcesManager resourcesManager;


    public void StartUp()
    {
        leavesParent.SetActive(true);
        bowl.SetActive(true);
    }

    public void ObjectAdded(bool isBark)
    {
        if (!isBark)
        {
            leavesAdded++;
            if (leavesAdded == leaves.Length)
            {
                alchemyStage++;
                leavesParent.SetActive(false);
                mixer.gameObject.SetActive(true);
                handle.gameObject.SetActive(true);
                Debug.Log("All leaves are added");
            }
        }
        else
        {
            barkAdded++;
            if (barkAdded == bark.Length)
            {
                alchemyStage = 2;
                barkParent.SetActive(false);
                mixer.gameObject.SetActive(true);
                handle.gameObject.SetActive(true);
                Debug.Log("bark is Finished");
            }
        }
    }

    public void MixingFinished()
    {
        if(alchemyStage == 1)
        {
            alchemyStage++;
            barkParent?.SetActive(true);
            mixer.gameObject.SetActive(false);
            handle.gameObject.SetActive(false);
            return;
        }
        if(alchemyStage == 2)
        {
            mixer.gameObject.SetActive(false);
            handle.gameObject.SetActive(false);
            endButton.SetActive(true);
        }
    }
    
    public void EndAlchemy()
    {
        endButton.SetActive(true);
        bowl.SetActive(false);
        resourcesManager.enabled = false;

        if(resourcesManager.collectedBoth && resourcesManager.timeManager.timeLeft != 0)
        {
            dialogueManager.EndDialogue(true);
        }
        else
        {
            dialogueManager.EndDialogue(false);
        }
        
    }


}
