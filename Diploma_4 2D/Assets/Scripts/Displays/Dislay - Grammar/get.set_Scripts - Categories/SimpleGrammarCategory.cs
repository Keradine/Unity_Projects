using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrammarCategory
{
    public int SimpleGrammarCategoryID { get; set; }
    public string SimpleCategoryName { get; set; }

    public SimpleGrammarCategory(int simpleGrammarCategoryID, string simpleCategoryName)
    {
        this.SimpleGrammarCategoryID = simpleGrammarCategoryID;
        this.SimpleCategoryName = simpleCategoryName;
    }
}
