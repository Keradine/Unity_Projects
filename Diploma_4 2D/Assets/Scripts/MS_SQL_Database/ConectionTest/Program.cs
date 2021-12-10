using UnityEngine;
using System;
using System.Data.SqlClient;

public class Program : MonoBehaviour
{
    void Start()
    {
        ShowResults();
    }
    public void ShowResults()
    {
        Debug.Log("Getting Connection ...");
        SqlConnection conn = DBUtils.GetDBConnection();
        try
        {
            Debug.Log("Openning Connection ...");
            conn.Open();
            Debug.Log("Connection successful!");
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e.Message);
        }
        //Console.Read();
    }

}
