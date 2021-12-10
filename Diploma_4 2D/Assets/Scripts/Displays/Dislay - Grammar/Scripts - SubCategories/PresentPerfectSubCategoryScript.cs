using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentPerfectSubCategoryScript : MonoBehaviour
{
    public GameObject presentPerfectSubCategoryName;

    public void SetPresentPerfectSubCategory(string presentPerfectSubCategoryName)
    {
        this.presentPerfectSubCategoryName.GetComponent<Text>().text = presentPerfectSubCategoryName;
    }
}
