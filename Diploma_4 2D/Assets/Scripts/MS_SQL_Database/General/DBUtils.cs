using UnityEngine;
using System.Data.SqlClient;

public class DBUtils : MonoBehaviour
{
    public static SqlConnection GetDBConnection()
    {
        string datasource = @"127.0.0.1, 1434"; //предыдущая конфигурация порта - @"192.168.1.56, 1433" - поменял, т.к была ошибка "Snix_Connect"
        string database = "Diploma2D";
        string username = "Test";
        string password = "singirlalice136";

        return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
    }
}

