using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] timeUnits = new GameObject[6];
    public int timeLeft = 6;

    public void ReduceTime()
    {
        timeUnits[timeLeft-1].gameObject.SetActive(false);
        timeLeft--;

        if (timeLeft == 1)
        {
            timeUnits[0].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
