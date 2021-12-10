using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class ProgressiveCategoryScript : MonoBehaviour
{
    public GameObject progressiveCategoryID;
    public GameObject progressiveCategoryName;

    public void SetSimpleGrammarCategory(string progressiveCategoryID, string progressiveCategoryName)
    {
        this.progressiveCategoryID.GetComponent<Text>().text = progressiveCategoryID;
        this.progressiveCategoryName.GetComponent<Text>().text = progressiveCategoryName;
    }
}
