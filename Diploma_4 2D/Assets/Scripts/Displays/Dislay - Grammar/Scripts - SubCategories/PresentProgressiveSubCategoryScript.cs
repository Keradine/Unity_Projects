using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentProgressiveSubCategoryScript : MonoBehaviour
{
    public GameObject presentProgressiveSubCategoryName;

    public void SetPresentProgressiveSubCategory(string presentProgressiveSubCategoryName)
    {
        this.presentProgressiveSubCategoryName.GetComponent<Text>().text = presentProgressiveSubCategoryName;
    }
}
