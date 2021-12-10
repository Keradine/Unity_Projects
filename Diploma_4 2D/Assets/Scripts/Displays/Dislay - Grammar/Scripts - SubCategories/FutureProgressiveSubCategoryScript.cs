using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FutureProgressiveSubCategoryScript : MonoBehaviour
{
    public GameObject futureProgressiveSubCategoryName;

    public void SetFutureProgressiveSubCategory(string futureProgressiveSubCategoryName)
    {
        this.futureProgressiveSubCategoryName.GetComponent<Text>().text = futureProgressiveSubCategoryName;
    }
}
