using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;

public class SubCategoriesManager : MonoBehaviour
{
    //Simple
    private List<PresentSimpleSubCategory> presentSimpleSubCategory = new List<PresentSimpleSubCategory>();
    public GameObject presentSimpleSubCategoryPrefab;
    private List<PastSimpleSubCategory> pastSimpleSubCategory = new List<PastSimpleSubCategory>();
    public GameObject pastSimpleSubCategoryPrefab;
    public List<FutureSimpleSubCategory> futureSimpleSubCategory = new List<FutureSimpleSubCategory>();
    public GameObject futureSimpleSubCategoryPrefab;
    //Progressive
    public List<PresentProgressiveSubCategory> presentProgressiveSubCategory = new List<PresentProgressiveSubCategory>();
    public GameObject presentProgressiveSubCategoryPrefab;
    public List<PastProgressiveSubCategory> pastProgressiveSubCategory = new List<PastProgressiveSubCategory>();
    public GameObject pastProgressiveSubCategoryPrefab;
    public List<FutureProgressiveSubCategory> futureProgressiveSubCategory = new List<FutureProgressiveSubCategory>();
    public GameObject futureProgressiveSubCategoryPrefab;
    //Perfect
    public List<PresentPerfectSubCategory> presentPerfectSubCategory = new List<PresentPerfectSubCategory>();
    public GameObject presentPerfectSubCategoryPrefab;
    public List<PastPerfectSubCategory> pastPerfectSubCategory = new List<PastPerfectSubCategory>();
    public GameObject pastPerfectSubCategoryPrefab;
    public List<FuturePerfectSubCategory> futurePerfectSubCategory = new List<FuturePerfectSubCategory>();
    public GameObject futurePerfectSubCategoryPrefab;

    public Transform presentSimpleSubCategoryParent;
    public Transform pastSimpleSubCategoryParent;
    public Transform futureSimpleSubCategoryParent;
    public Transform presentProgressiveSubCategoryParent;
    public Transform pastProgressiveSubCategoryParent;
    public Transform futureProgressiveSubCategoryParent;
    public Transform presentPerfectSubCategoryParent;
    public Transform pastPerfectSubCategoryParent;
    public Transform futurePerfectSubCategoryParent;

    private void Start()
    {
        //Simple
        ShowPresentSimpleSubCategory();
        ShowPastSimpleSubCategory();
        ShowFutureSimpleSubCategory();
        //Progressive
        ShowPresentProgressiveSubCategory();
        ShowPastProgressiveSubCategory();
        ShowFutureProgressiveSubCategory();
        //Perfect
        ShowPresentPerfectSubCategory();
        ShowPastPerfectSubCategory();
        ShowFuturePerfectSubCategory();
    }

    private void ShowPresentSimpleSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=1 AND subCategoryID=1";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    presentSimpleSubCategory.Add(new PresentSimpleSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < presentSimpleSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(presentSimpleSubCategoryPrefab);
            PresentSimpleSubCategory tmpCategory = presentSimpleSubCategory[i];
            tmpObject.GetComponent<PresentSimpleSubCategoryScript>().SetPresentSimpleSubCategory(tmpCategory.PresentSimpleSubCategoryName.ToString()); //tmpObject.GetComponent<GrammarCategoryScript>().SetGrammarCategory(tmpCategory.GrammarCategoryID.ToString, "#" + (i + 1).ToString(), tmpCategory.CategoryName.ToString);
            tmpObject.transform.SetParent(presentSimpleSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void ShowPastSimpleSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=1 AND subCategoryID=2";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pastSimpleSubCategory.Add(new PastSimpleSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < pastSimpleSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(pastSimpleSubCategoryPrefab);
            PastSimpleSubCategory tmpCategory = pastSimpleSubCategory[i];
            tmpObject.GetComponent<PastSimpleSubCategoryScript>().SetPastSimpleSubCategory(tmpCategory.PastSimpleSubCategoryName.ToString()); 
            tmpObject.transform.SetParent(pastSimpleSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void ShowFutureSimpleSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=1 AND subCategoryID=3";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    futureSimpleSubCategory.Add(new FutureSimpleSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < futureSimpleSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(futureSimpleSubCategoryPrefab);
            FutureSimpleSubCategory tmpCategory = futureSimpleSubCategory[i];
            tmpObject.GetComponent<FutureSimpleSubCategoryScript>().SetFutureSimpleSubCategory(tmpCategory.FutureSimpleSubCategoryName.ToString()); 
            tmpObject.transform.SetParent(futureSimpleSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
    private void ShowPresentProgressiveSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=2 AND subCategoryID=4";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    presentProgressiveSubCategory.Add(new PresentProgressiveSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < presentProgressiveSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(presentProgressiveSubCategoryPrefab);
            PresentProgressiveSubCategory tmpCategory = presentProgressiveSubCategory[i];
            tmpObject.GetComponent<PresentProgressiveSubCategoryScript>().SetPresentProgressiveSubCategory(tmpCategory.PresentProgressiveSubCategoryName.ToString()); 
            tmpObject.transform.SetParent(presentProgressiveSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void ShowPastProgressiveSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=2 AND subCategoryID=5";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pastProgressiveSubCategory.Add(new PastProgressiveSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < pastProgressiveSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(pastProgressiveSubCategoryPrefab);
            PastProgressiveSubCategory tmpCategory = pastProgressiveSubCategory[i];
            tmpObject.GetComponent<PastProgressiveSubCategoryScript>().SetPastProgressiveSubCategory(tmpCategory.PastProgressiveSubCategoryName.ToString()); 
            tmpObject.transform.SetParent(pastProgressiveSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void ShowFutureProgressiveSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=2 AND subCategoryID=6";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    futureProgressiveSubCategory.Add(new FutureProgressiveSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < futureProgressiveSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(futureProgressiveSubCategoryPrefab);
            FutureProgressiveSubCategory tmpCategory = futureProgressiveSubCategory[i];
            tmpObject.GetComponent<FutureProgressiveSubCategoryScript>().SetFutureProgressiveSubCategory(tmpCategory.FutureProgressiveSubCategoryName.ToString()); 
            tmpObject.transform.SetParent(futureProgressiveSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
    private void ShowPresentPerfectSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=3 AND subCategoryID=7";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    presentPerfectSubCategory.Add(new PresentPerfectSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < presentPerfectSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(presentPerfectSubCategoryPrefab);
            PresentPerfectSubCategory tmpCategory = presentPerfectSubCategory[i];
            tmpObject.GetComponent<PresentPerfectSubCategoryScript>().SetPresentPerfectSubCategory(tmpCategory.PresentPerfectSubCategoryName.ToString()); 
            tmpObject.transform.SetParent(presentPerfectSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
    private void ShowPastPerfectSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=3 AND subCategoryID=8";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pastPerfectSubCategory.Add(new PastPerfectSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < pastPerfectSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(pastPerfectSubCategoryPrefab);
            PastPerfectSubCategory tmpCategory = pastPerfectSubCategory[i];
            tmpObject.GetComponent<PastPerfectSubCategoryScript>().SetPastPerfectSubCategory(tmpCategory.PastPerfectSubCategoryName.ToString()); 
            tmpObject.transform.SetParent(pastPerfectSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
    private void ShowFuturePerfectSubCategory()
    {
        string queryString = "SELECT subCategoryName FROM SubCategory WHERE grammarCategoryID=3 AND subCategoryID=9";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    futurePerfectSubCategory.Add(new FuturePerfectSubCategory(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < futurePerfectSubCategory.Count; i++)
        {
            GameObject tmpObject = Instantiate(futurePerfectSubCategoryPrefab);
            FuturePerfectSubCategory tmpCategory = futurePerfectSubCategory[i];
            tmpObject.GetComponent<FuturePerfectSubCategoryScript>().SetFuturePerfectSubCategory(tmpCategory.FuturePerfectSubCategoryName.ToString()); 
            tmpObject.transform.SetParent(futurePerfectSubCategoryParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
