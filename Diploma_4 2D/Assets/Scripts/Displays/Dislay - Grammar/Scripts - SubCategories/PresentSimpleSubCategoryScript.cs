using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentSimpleSubCategoryScript : MonoBehaviour
{
    public GameObject presentSimpleSubCategoryName;

    public void SetPresentSimpleSubCategory(string presentSimpleSubCategoryName)
    {
        this.presentSimpleSubCategoryName.GetComponent<Text>().text = presentSimpleSubCategoryName;
    }
}
