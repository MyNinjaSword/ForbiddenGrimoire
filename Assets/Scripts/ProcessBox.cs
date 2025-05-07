using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessBox : MonoBehaviour
{
    public bool isProcessSelected;
    public GameObject processDisplay;
    public GameObject plusSign;
    public GameObject xSign;

    public void ProcessDisplay(GameObject process)
    {
        //GameObject gameObject = Instantiate(process);
        //gameObject.SetActive(true);
        //gameObject.transform.SetParent(processDisplay.transform, false);
        plusSign.SetActive(false);
        xSign.SetActive(true);
    }

    public void NextUp()
    {
        plusSign.SetActive(true);
        xSign.SetActive(false);
    }
}
