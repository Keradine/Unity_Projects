using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressiveGrammarCategory
{
    public int ProgressiveCategoryID { get; set; }
    public string ProgressiveCategoryName { get; set; }

    public ProgressiveGrammarCategory(int progressiveCategoryID, string progressiveCategoryName)
    {
        this.ProgressiveCategoryID = progressiveCategoryID;
        this.ProgressiveCategoryName = progressiveCategoryName;
    }
}
