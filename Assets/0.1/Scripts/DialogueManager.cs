using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextAsset[] textFiles;
    public TextMeshProUGUI[] buttonsText;
    public TextMeshProUGUI dialogueBox;
    public ButtonManager[] buttonManagers;
    public GameObject resourceMan;

    private TextAsset currentTextFile;

    private Queue<string> dialogue = new Queue<string>();

    private string constructedLine;
    private bool isTyping = false;
    public bool dialogueFinished = false;

    private int dialogueOptions;
    private bool chooseDialogue = false;

    private int currentConversation = 0;

    private List<string> dialogueOptionsText = new List<string>();

    private List<int> visitedConversations = new List<int>();

    private bool lastDialogue;

    private bool isEnding = false;

    public AlchamyManager alchMan;

    float delay = 0.05f;



    void Start()
    {
        ReadTextFile(currentConversation);
        visitedConversations.Add(currentConversation);
    }

    private void ReadTextFile(int fileNumber)
    {
        if(fileNumber == 99)
        {
            dialogueBox.enabled = false;
            buttonManagers[0].gameObject.SetActive(false);
            buttonManagers[1].gameObject.SetActive(false);
            buttonManagers[2].gameObject.SetActive(false);
            resourceMan.SetActive(true);
            return;
        }
        dialogueFinished = false;
        string txt = textFiles[fileNumber].text;

        string[] lines = txt.Split(System.Environment.NewLine.ToCharArray()); // Split dialogue lines by newline
        dialogueOptions = 0;
        dialogueOptionsText.Add("...");
        dialogueOptionsText.Clear();

        foreach (string line in lines) // for every line of dialogue
        {
            if (!string.IsNullOrEmpty(line))// ignore empty lines of dialogue
            {
                if (line[0] == '[')
                {
                    dialogueOptions++;
                    int correctDialogue = dialogueOptions - 1;
                    dialogueOptionsText.Add(line.Remove(0,1));// sets dialogue aside for buttons
                    
                }
                else
                {
                    dialogue.Enqueue(line); // adds to the dialogue to be printed
                }
                
            }
        }
        if(dialogueOptions == 0)
        {
            dialogueOptions++;
            
        }
        else
        {
            
        }
        foreach (TextMeshProUGUI button in buttonsText)
        {
            button.gameObject.transform.parent.transform.gameObject.SetActive(false);
        }
        buttonsText[0].text = "...";
        buttonsText[0].gameObject.transform.parent.transform.gameObject.SetActive(true);
        buttonManagers[0].targetConversation = 0;
        AdvanceDialogue(0);
    }

    public void AdvanceDialogue(int targetConversation)
    {
        if(isTyping)
        {
            delay = 0;   
            return;
        }
        if(targetConversation == 99)
        {
            lastDialogue = true;
        }
        if (targetConversation != 0)
        {
            currentConversation = --targetConversation;
            EndDialogue();
            return;
        }
        if (dialogue.Count == 0 && dialogueOptions == 1) 
        {
            EndDialogue();
            return;
        }
        else if(dialogue.Count == 1 && dialogueOptions >= 1)
        {
            StartCoroutine(PrintOutText());
            PlayerChoose();
            return;
        }
        

        StartCoroutine(PrintOutText());

    }

    private IEnumerator PrintOutText()
    {
        string fullText = dialogue.Peek();
        //dialogueBox.text = "";
        isTyping = true;
        int closeIndex = 0;
        bool highlightSpeed = false;

        int i = 0;
        while (i < fullText.Length)
        {
            if (fullText[i] == '<')
            {
                // Detect and append entire rich text tag
                closeIndex = fullText.IndexOf('>', i);
                if (closeIndex != -1)
                {
                    string tag = fullText.Substring(i, closeIndex - i + 1);
                    dialogueBox.text += tag;
                    i = closeIndex + 1;

                    continue;
                }
            }

            dialogueBox.text += fullText[i];
            i++;
            yield return new WaitForSeconds(delay);
        }
        dialogueBox.text += "\n\n";
        dialogue.Dequeue();
        isTyping = false;
        delay = 0.05f;


        if (currentConversation != 99)
        {
            buttonsText[0].gameObject.transform.parent.transform.gameObject.SetActive(true);
        }

    }

    private void PlayerChoose()
    {
        if(currentConversation ==99 )
        {
            return;
        }
        
        dialogueOptionsText.Reverse();
        for (int i = 0; i < dialogueOptions; i++)
        {
            buttonManagers[i].gameObject.SetActive(true);
            if(dialogueOptionsText.Count > 0)
            {
                buttonsText[i].text = dialogueOptionsText[i];
            }
            buttonsText[i].fontSize = 177;
        }
        if (currentConversation == 1)
        {
            buttonManagers[2].targetConversation = 3;
            buttonManagers[1].targetConversation = 4;
            buttonManagers[0].targetConversation = 5;

        }
        if (currentConversation == 3)
        {
            buttonManagers[1].targetConversation = 4;
            buttonManagers[0].targetConversation = 5;
        }
        if (currentConversation == 4)
        {
            buttonManagers[1].targetConversation = 3;
            buttonManagers[0].targetConversation = 5;
        }
        if (currentConversation == 5)
        {
            buttonManagers[0].targetConversation = 6;
        }
        if (currentConversation == 6)
        {
            buttonManagers[0].targetConversation = 7;
            buttonsText[0].fontSize = 125;

        }
        if (currentConversation == 7)
        {
            buttonManagers[0].targetConversation = 8;
            buttonsText[0].fontSize = 125;
            buttonManagers[1].targetConversation = 9;
            buttonsText[1].fontSize = 125;
        }
        if (currentConversation == 10)
        {
            buttonManagers[0].targetConversation = 99;
            /*
            
            */
        }
        if (currentConversation == 8 || currentConversation == 9)
        {
            buttonManagers[0].targetConversation = 10;
            buttonsText[0].fontSize = 125;
        }
        if( currentConversation == 11)
        {
            buttonManagers[0].targetConversation = 99;
            if(isEnding == false)
            {
                return;
            }
        }


        if( currentConversation == 11)
        {
            buttonManagers[0].targetConversation = 12;
        }
        if(currentConversation == 12)
        {
            buttonManagers[0].targetConversation = 14;
            buttonManagers[1].targetConversation = 13;
        }
        if(currentConversation == 13 || currentConversation == 14)
        {
            buttonManagers[0].targetConversation = 15;
        }
        if(currentConversation == 15)
        {
            buttonManagers[0].targetConversation = 98;
            Debug.Log("end of game");
        }
        if(currentConversation == 16) //bad ending start
        {
            buttonManagers[0].targetConversation = 17;
        }
        if (currentConversation == 17)
        {
            buttonManagers[0].targetConversation = 18;
        }
        if (currentConversation == 18)
        {
            buttonManagers[0].targetConversation = 21;
            buttonsText[0].fontSize = 125;
            buttonManagers[1].targetConversation = 20;
            buttonManagers[2].targetConversation = 19;

        }
        if (currentConversation == 19|| currentConversation == 20 || currentConversation == 21)
        {
            Debug.Log("end of game");
            buttonManagers[0].targetConversation = 98;
        }
    }

    private void EndDialogue()
    {
        dialogueBox.text = "";
        currentConversation++;
        Start();
        
    }

    public void EndDialogue(bool goodEnding)
    {
        dialogueBox.enabled = true;
        alchMan.endButton.SetActive(false);
        if (goodEnding)
        {
            currentConversation = 11;
        }
        else
        {
            currentConversation = 16;
        }
        isEnding = true;
        AdvanceDialogue(currentConversation);

    }




}
