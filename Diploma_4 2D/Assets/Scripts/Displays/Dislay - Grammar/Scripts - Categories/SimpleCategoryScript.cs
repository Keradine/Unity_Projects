using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCategoryScript : MonoBehaviour
{
    public GameObject simpleGrammarCategoryID;
    public GameObject simpleCategoryName;

    public void SetSimpleGrammarCategory (string simpleGrammarCategoryID, string simpleCategoryName)
    {
        this.simpleGrammarCategoryID.GetComponent<Text>().text = simpleGrammarCategoryID;
        this.simpleCategoryName.GetComponent<Text>().text = simpleCategoryName;
    }
}
