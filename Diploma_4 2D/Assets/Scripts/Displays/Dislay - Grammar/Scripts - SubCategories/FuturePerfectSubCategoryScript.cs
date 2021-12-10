using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuturePerfectSubCategoryScript : MonoBehaviour
{
    public GameObject futurePerfectSubCategoryName;

    public void SetFuturePerfectSubCategory(string futurePerfectSubCategoryName)
    {
        this.futurePerfectSubCategoryName.GetComponent<Text>().text = futurePerfectSubCategoryName;
    }
}
