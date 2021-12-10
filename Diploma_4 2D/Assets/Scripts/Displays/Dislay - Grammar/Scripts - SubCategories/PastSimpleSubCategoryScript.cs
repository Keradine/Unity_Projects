using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastSimpleSubCategoryScript : MonoBehaviour
{
    public GameObject pastSimpleSubCategoryName;

    public void SetPastSimpleSubCategory(string pastSimpleSubCategoryName)
    {
        this.pastSimpleSubCategoryName.GetComponent<Text>().text = pastSimpleSubCategoryName;
    }
}
