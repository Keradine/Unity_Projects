using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;

public class SimpleTenseManager : MonoBehaviour
{
    //Title
    public List<SimpleCategoryTitle> simpleCategoryTitle = new List<SimpleCategoryTitle>();
    public GameObject simpleCategoryTitlePrefab;

    //Buttons
    public List<PresentSimpleButton> presentSimpleButton = new List<PresentSimpleButton>();
    public GameObject presentSimpleButtonPrefab;
    public List<PastSimpleButton> pastSimpleButton = new List<PastSimpleButton>();
    public GameObject pastSimpleButtonPrefab;
    public List<FutureSimpleButton> futureSimpleButton = new List<FutureSimpleButton>();
    public GameObject futureSimpleButtonPrefab;

    public Transform simpleCategoryTitleParent;
    public Transform presentSimpleButtonParent;
    public Transform pastSimpleButtonParent;
    public Transform futureSimpleButtonParent;

    private void Start()
    {
        ShowSimpleCategoryTitle();
        ShowPresentSimpleButton();
        ShowPastSimpleButton();
        ShowFutureSimpleButton();
    }

    private void ShowSimpleCategoryTitle()
    {
        string queryString = "SELECT categoryName FROM GrammarCategory WHERE grammarCategoryID=1";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    simpleCategoryTitle.Add(new SimpleCategoryTitle(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < simpleCategoryTitle.Count; i++)
        {
            GameObject tmpObject = Instantiate(simpleCategoryTitlePrefab);
            SimpleCategoryTitle tmpCategory = simpleCategoryTitle[i];
            tmpObject.GetComponent<SimpleCategoryTitleScript>().SetSimpleCategoryTitle(tmpCategory.SimpleCategoryTitleName.ToString()); 
            tmpObject.transform.SetParent(simpleCategoryTitleParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void ShowPresentSimpleButton()
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
                    presentSimpleButton.Add(new PresentSimpleButton(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < presentSimpleButton.Count; i++)
        {
            GameObject tmpObject = Instantiate(presentSimpleButtonPrefab);
            PresentSimpleButton tmpCategory = presentSimpleButton[i];
            tmpObject.GetComponent<PresentSimpleButtonScript>().SetPresentSimpleButton(tmpCategory.PresentSimpleButtonName.ToString());
            tmpObject.transform.SetParent(presentSimpleButtonParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void ShowPastSimpleButton()
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
                    pastSimpleButton.Add(new PastSimpleButton(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < pastSimpleButton.Count; i++)
        {
            GameObject tmpObject = Instantiate(pastSimpleButtonPrefab);
            PastSimpleButton tmpCategory = pastSimpleButton[i];
            tmpObject.GetComponent<PastSimpleButtonScript>().SetPastSimpleButton(tmpCategory.PastSimpleButtonName.ToString());
            tmpObject.transform.SetParent(pastSimpleButtonParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void ShowFutureSimpleButton()
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
                    futureSimpleButton.Add(new FutureSimpleButton(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < futureSimpleButton.Count; i++)
        {
            GameObject tmpObject = Instantiate(futureSimpleButtonPrefab);
            FutureSimpleButton tmpCategory = futureSimpleButton[i];
            tmpObject.GetComponent<FutureSimpleButtonScript>().SetFutureSimpleButton(tmpCategory.FutureSimpleButtonName.ToString());
            tmpObject.transform.SetParent(futureSimpleButtonParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
