/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;

public class Manager : MonoBehaviour
{
    private void ShowGrammarCategory(int grammarCategoryID)
    {
        string queryString = "SELECT grammarCategoryID, categoryName FROM GrammarCategory WHERE grammarCategoryID=" + grammarCategoryID;
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (grammarCategoryID == 1) simpleGrammarCategory.Add(new SimpleGrammarCategory(reader.GetInt32(0), reader.GetString(1)));
                    if (grammarCategoryID == 2) progressiveGrammarCategory.Add(new ProgressiveGrammarCategory(reader.GetInt32(0), reader.GetString(1)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < simpleGrammarCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(simpleCategoryPrefab);
            SimpleGrammarCategory tmpCategory = simpleGrammarCategory[i];
            tmpObject.GetComponent<SimpleCategoryScript>().SetSimpleGrammarCategory(tmpCategory.SimpleGrammarCategoryID.ToString(), tmpCategory.SimpleCategoryName.ToString()); //tmpObject.GetComponent<GrammarCategoryScript>().SetGrammarCategory(tmpCategory.GrammarCategoryID.ToString, "#" + (i + 1).ToString(), tmpCategory.CategoryName.ToString);
            tmpObject.transform.SetParent(simpleCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}*/
