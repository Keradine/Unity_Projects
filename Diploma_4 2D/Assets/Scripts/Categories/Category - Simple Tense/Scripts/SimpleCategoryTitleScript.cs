using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCategoryTitleScript : MonoBehaviour
{
    public GameObject simpleCategoryTitleName;

    public void SetSimpleCategoryTitle(string simpleCategoryTitleName)
    {
        this.simpleCategoryTitleName.GetComponent<Text>().text = simpleCategoryTitleName;
    }
}
