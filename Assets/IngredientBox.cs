using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientBox : MonoBehaviour
{
    public bool ingredientSelected;
    public GameObject ingredientDisplay;
    public GameObject plusSign;
    public GameObject xSign;

    public TextMeshProUGUI qualityOne;
    public TextMeshProUGUI qualityTwo;
    public TextMeshProUGUI qualityThree;

    public void IngredientDisplay(GameObject ingredient)
    {
        GameObject gameObject = Instantiate(ingredient);
        gameObject.SetActive(true);
        gameObject.transform.SetParent(ingredientDisplay.transform, false);
        plusSign.SetActive(false);
        xSign.SetActive(true);
    }
}
