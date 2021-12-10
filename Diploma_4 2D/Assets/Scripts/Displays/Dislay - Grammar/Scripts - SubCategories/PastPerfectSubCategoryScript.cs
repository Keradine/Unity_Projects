using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastPerfectSubCategoryScript : MonoBehaviour
{
    public GameObject pastPerfectSubCategoryName;

    public void SetPastPerfectSubCategory(string pastPerfectSubCategoryName)
    {
        this.pastPerfectSubCategoryName.GetComponent<Text>().text = pastPerfectSubCategoryName;
    }
}
