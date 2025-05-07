using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentPanel = 0; // 0 = setupPanel, 1 = ingriedients, 2 = Process
    private SetUpPanel setUpPanel;
    private IngredientsSelection ingSelection;
    private ProcessSelection procSelection;
    private List<GameObject> gameMenus = new List<GameObject>();
    public List<string> ingredientTags = new List<string>();

    //selecting ingredients
    public GameObject[] selectionBoxesObjects = new GameObject[3];
    public IngredientBox[] selectionBoxes = new IngredientBox[3];
    private int boxesOccupied = 0;
    public List<GameObject> possibleIngredients = new List<GameObject>();
    public List<string> activeIngredients = new List<string>();
    public GameObject[] crossBoxes = new GameObject[2];//used for blocking player from selecting in further boxes

    //Process Boxes
    public GameObject processStepBoxObject;//do we need?
    public List<GameObject> processBoxesObjects = new List<GameObject>();
    public List<ProcessBox> proccessBoxScripts;
    private int processStepsAdded = 0;
    public List<string> stepsAdded = new List<string>();
    public GameObject processParent;

    private void Awake()
    {
        {
            setUpPanel = GetComponentInChildren<SetUpPanel>();
            ingSelection = GetComponentInChildren<IngredientsSelection>();
            procSelection = GetComponentInChildren<ProcessSelection>();
        }

        {
            gameMenus.Add(setUpPanel.gameObject);
            gameMenus.Add(ingSelection.gameObject);
            gameMenus.Add(procSelection.gameObject);
            foreach (GameObject go in gameMenus) { go.SetActive(false); }
            setUpPanel.gameObject.SetActive(true);
            selectionBoxes[1].plusSign.SetActive(false);
            selectionBoxes[2].plusSign.SetActive(false);
        }
    }

    public void ChangeMenu(int menu)
    {
        if(currentPanel == menu) return;

        currentPanel = menu;
        
        foreach(GameObject go in gameMenus) { go.SetActive(false); }

        gameMenus[menu].SetActive(true);
    }

    public void IngredientSelected(int idIngredient)
    {
        if (activeIngredients.Contains(ingredientTags[idIngredient]))
        {
            return;
        }
        activeIngredients.Add(ingredientTags[idIngredient]);

        selectionBoxes[boxesOccupied].isIngredientSelected = true;
        GameObject bufferObject = Instantiate(possibleIngredients[idIngredient], selectionBoxesObjects[boxesOccupied].transform, false);
        bufferObject.SetActive(true);
        var rectTransform = bufferObject.GetComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0.5f, 0);
        rectTransform.anchoredPosition = Vector2.zero;
        selectionBoxes[boxesOccupied].isIngredientSelected = true;
        selectionBoxes[boxesOccupied].plusSign.SetActive(false);
        selectionBoxes[boxesOccupied].xSign.SetActive(true);  
        selectionBoxes[boxesOccupied].ingredientDisplay = bufferObject;
        boxesOccupied++;

        if (boxesOccupied == 1)
        {
            selectionBoxes[1].plusSign.SetActive(true);
            crossBoxes[0].SetActive(false);
        }
        else if (boxesOccupied == 2)
        {
            selectionBoxes[2].plusSign.SetActive(true);
            crossBoxes[1].SetActive(false);
        }

    }

    public void ClearSelection(int idIngredient)
    {
        boxesOccupied--;
        selectionBoxes[boxesOccupied].isIngredientSelected = false;
        selectionBoxes[boxesOccupied].plusSign.SetActive(true);
        selectionBoxes[boxesOccupied].xSign.SetActive(false);
        activeIngredients.Remove(activeIngredients[(int)idIngredient]);
        Destroy(selectionBoxes[idIngredient].ingredientDisplay.gameObject);

        if(boxesOccupied == 1)
        {
            selectionBoxes[2].plusSign.SetActive(false);
            crossBoxes[2].SetActive(true);
        }
        if (boxesOccupied == 0)
        {
            
        }
    }

    public void AddProcess()
    {
        if(processStepsAdded == 5) //put big x here
        {
            return;
        }
        processStepsAdded++;
        ChangeMenu(2);
        GameObject bufferObject = Instantiate(processStepBoxObject, processParent.transform, false);
        RectTransform rectTransform = bufferObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(50 + (250 * processStepsAdded), 150);
        ProcessBox procBox = bufferObject.GetComponent<ProcessBox>();
        procBox.NextUp();
        proccessBoxScripts.Add(procBox);
        processBoxesObjects.Add(procBox.gameObject);
        proccessBoxScripts[processStepsAdded - 1].ProcessDisplay(bufferObject);
        proccessBoxScripts[processStepsAdded - 1].isProcessSelected = true;

        if (processStepsAdded -2 >+ 0)
        {
            proccessBoxScripts[processStepsAdded - 2].xSign.SetActive(false); 
        }
        if(processStepsAdded == 2)
        {
            proccessBoxScripts[0].xSign.SetActive(false);
        }
    }

    public void RemoveProcess()
    {
        Destroy(proccessBoxScripts[processStepsAdded].gameObject);
        Destroy(proccessBoxScripts[processStepsAdded - 1].gameObject);
        processStepsAdded--;
        proccessBoxScripts[processStepsAdded-1].xSign.SetActive(true);
    }



}
