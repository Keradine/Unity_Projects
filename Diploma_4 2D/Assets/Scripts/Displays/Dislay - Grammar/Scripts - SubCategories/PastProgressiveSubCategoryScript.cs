using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastProgressiveSubCategoryScript : MonoBehaviour
{
    public GameObject pastProgressiveSubCategoryName;

    public void SetPastProgressiveSubCategory(string pastProgressiveSubCategoryName)
    {
        this.pastProgressiveSubCategoryName.GetComponent<Text>().text = pastProgressiveSubCategoryName;
    }
}
