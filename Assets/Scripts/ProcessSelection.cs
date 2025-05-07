using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSelection : MonoBehaviour
{
    public GameManager gameMan;

    private int processStep; // 0 is category, 1 is actual process, 2 is ingredient selection and description, 4 shows end product

    public GameObject[] refiningOptions = new GameObject[3];
    public GameObject[] combingingOptions = new GameObject[3];

    public void OnCategorySelection(int catNumber)
    {
        if(catNumber == 0)
        {
            processStep++;
            foreach(GameObject boop in refiningOptions)
            {
                boop.SetActive(true);
            }
        }

        //gameMan.ChangeMenu(0);
    }










}
