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

    //selecting ingredients
    public GameObject[] selectionBoxesObjects = new GameObject[3];
    public IngredientBox[] selectionBoxes = new IngredientBox[3];
    private int boxesOccupied;
    public List<GameObject> possibleIngredients = new List<GameObject>();

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
        }
    }

    public void ChangeMenu(int menu)
    {
        if(currentPanel == menu) return;

        currentPanel = menu;
        
        foreach(GameObject go in gameMenus) { go.SetActive(false); }

        gameMenus[menu].SetActive(true);
    }

    public void IngredientSelected(int id)
    {
        selectionBoxes[boxesOccupied].ingredientSelected = true;
        GameObject bufferObject = Instantiate(possibleIngredients[id], selectionBoxesObjects[boxesOccupied].transform, false);
        bufferObject.SetActive(true);
        var rectTransform = bufferObject.GetComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0.5f, 0);
        rectTransform.anchoredPosition = Vector2.zero;
        boxesOccupied++;
    }



}
