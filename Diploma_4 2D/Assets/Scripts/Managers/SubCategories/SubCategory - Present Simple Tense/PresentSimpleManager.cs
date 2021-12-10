using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;

public class PresentSimpleManager : MonoBehaviour
{
    public List<PresentSimpleTitle> presentSimpleTitle = new List<PresentSimpleTitle>();
    public GameObject presentSimpleTitlePrefab;

    public Transform presentSimpleTitleParent;

    void Start()
    {
        ShowPresentSimpleTitle();
    }

    private void ShowPresentSimpleTitle()
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
                    presentSimpleTitle.Add(new PresentSimpleTitle(reader.GetString(0)));
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        for (int i = 0; i < presentSimpleTitle.Count; i++)
        {
            GameObject tmpObject = Instantiate(presentSimpleTitlePrefab);
            PresentSimpleTitle tmpCategory = presentSimpleTitle[i];
            tmpObject.GetComponent<PresentSimpleTitleScript>().SetPresentSimpleTitle(tmpCategory.PresentSimpleTitleName.ToString());
            tmpObject.transform.SetParent(presentSimpleTitleParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
