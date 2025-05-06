using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentPanel = 0; // 0 = setupPanel, 1 = ingriedients, 2 = Process
    private SetUpPanel setUpPanel;
    private IngredientsSelection ingSelection;
    private ProcessSelection procSelection;

    private void Awake()
    {
        setUpPanel = GetComponentInChildren<SetUpPanel>();
        ingSelection = GetComponentInChildren<IngredientsSelection>();
        procSelection = GetComponentInChildren<ProcessSelection>();
    }

    public void ChangeMenu(int menu)
    {
        if(currentPanel == menu) return;

        if(currentPanel == 0)
        {
            setUpPanel


        }
        if(currentPanel == 1)
        {

        }
        if(currentPanel == 2)
        {

        }
    }



}
