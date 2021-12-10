using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class PerfectCategoryScript : MonoBehaviour
{
    public GameObject perfectCategoryID;
    public GameObject perfectCategoryName;

    public void SetSimpleGrammarCategory(string perfectCategoryID, string perfectCategoryName)
    {
        this.perfectCategoryID.GetComponent<Text>().text = perfectCategoryID;
        this.perfectCategoryName.GetComponent<Text>().text = perfectCategoryName;
    }
}
