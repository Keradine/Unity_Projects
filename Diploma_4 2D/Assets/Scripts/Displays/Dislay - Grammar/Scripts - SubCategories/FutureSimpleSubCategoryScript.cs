using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FutureSimpleSubCategoryScript : MonoBehaviour
{
    public GameObject futureSimpleSubCategoryName;

    public void SetFutureSimpleSubCategory(string futureSimpleSubCategoryName)
    {
        this.futureSimpleSubCategoryName.GetComponent<Text>().text = futureSimpleSubCategoryName;
    }
}
