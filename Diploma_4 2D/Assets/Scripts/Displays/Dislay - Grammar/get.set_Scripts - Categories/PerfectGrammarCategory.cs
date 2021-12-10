using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectGrammarCategory
{
    public int PerfectCategoryID { get; set; }
    public string PerfectCategoryName { get; set; }

    public PerfectGrammarCategory(int perfectCategoryID, string perfectCategoryName)
    {
        this.PerfectCategoryID = perfectCategoryID;
        this.PerfectCategoryName = perfectCategoryName;
    }
}
