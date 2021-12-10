using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;

public class CategoriesManager : MonoBehaviour
{
    private List<SimpleGrammarCategory> simpleGrammarCategory = new List<SimpleGrammarCategory>();
    public GameObject simpleCategoryPrefab;

    private List<ProgressiveGrammarCategory> progressiveGrammarCategory = new List<ProgressiveGrammarCategory>();
    public GameObject progressiveCategoryPrefab;

    private List<PerfectGrammarCategory> perfectGrammarCategory = new List<PerfectGrammarCategory>();
    public GameObject perfectCategoryPrefab;

    public Transform simpleCategoryParent;
    public Transform progressiveCategoryParent;
    public Transform perfectCategoryParent;

    private void Start()
    {
        ShowSimpleCategory();
        ShowProgressiveCategory();
        ShowPerfectCategory();
    }
    private void ShowSimpleCategory()
    {
        string queryString = "SELECT grammarCategoryID, categoryName FROM GrammarCategory WHERE grammarCategoryID=1";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    simpleGrammarCategory.Add(new SimpleGrammarCategory(reader.GetInt32(0), reader.GetString(1)));
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
    private void ShowProgressiveCategory()
    {
        string queryString = "SELECT grammarCategoryID, categoryName FROM GrammarCategory WHERE grammarCategoryID=2";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    progressiveGrammarCategory.Add(new ProgressiveGrammarCategory(reader.GetInt32(0), reader.GetString(1)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < progressiveGrammarCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(progressiveCategoryPrefab);
            ProgressiveGrammarCategory tmpCategory = progressiveGrammarCategory[i];
            tmpObject.GetComponent<ProgressiveCategoryScript>().SetSimpleGrammarCategory(tmpCategory.ProgressiveCategoryID.ToString(), tmpCategory.ProgressiveCategoryName.ToString()); 
            tmpObject.transform.SetParent(progressiveCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void ShowPerfectCategory()
    {
        string queryString = "SELECT grammarCategoryID, categoryName FROM GrammarCategory WHERE grammarCategoryID=3";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    perfectGrammarCategory.Add(new PerfectGrammarCategory(reader.GetInt32(0), reader.GetString(1)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < perfectGrammarCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(perfectCategoryPrefab);
            PerfectGrammarCategory tmpCategory = perfectGrammarCategory[i];
            tmpObject.GetComponent<PerfectCategoryScript>().SetSimpleGrammarCategory(tmpCategory.PerfectCategoryID.ToString(), tmpCategory.PerfectCategoryName.ToString()); 
            tmpObject.transform.SetParent(perfectCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
