using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    DialogueManager dialogueManager;
    public int targetConversation;

    void Start()
    {
        dialogueManager = this.gameObject.transform.GetComponentInParent<DialogueManager>();
    }

    public void ButtonPressed()
    {
        dialogueManager.AdvanceDialogue(targetConversation);

        if(targetConversation == 98)
        {
            Application.Quit();
        }
    }
}
