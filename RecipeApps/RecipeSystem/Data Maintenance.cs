using CPUFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class Data_Maintenance
    {
        public static DataTable GetDataList(string tablename, bool IncludeBlank = false)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand(tablename + "get");
            SQLUtility.SetParamValue(cmd, "@all", 1);
            if (IncludeBlank == true)
            {
                SQLUtility.SetParamValue(cmd, "@IncludeBlank", IncludeBlank);
            }
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveDataList(DataTable dt, string tablename)
        {
            SQLUtility.SaveDataTable(dt, tablename + "update");
        }

        public static void DeleteRow(string tablename, int ID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand(tablename + "delete");
            SQLUtility.SetParamValue(cmd, $"@{tablename}id", ID);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static DataTable GetDashboard()
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("DashboardGet");

            return SQLUtility.GetDataTable(cmd);
        }
    }
}

