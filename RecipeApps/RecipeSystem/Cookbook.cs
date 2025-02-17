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
    public class Cookbook
    {

        public static DataTable Load(int CookbookID)
        {

            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("CookbookGet");
            SQLUtility.SetParamValue(cmd, "@CookbookID", CookbookID);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;

        }

        public static string GetCookbookDescription(DataTable dtcookbook)
        {
            string value = "New Cookbook";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "cookbookid");
            if (pkvalue > 0)
            {
                value = "Cookbook" + " - " + SQLUtility.GetValueFromFirstRowAsString(dtcookbook, "Cookbookname");
            }

            return value;
        }

        public static void Delete(DataTable dtcookbook)
        {
            int id = (int)dtcookbook.Rows[0]["cookbookID"];
            SqlCommand cmd = SQLUtility.GetSqlcommand("CookbookDelete");
            SQLUtility.SetParamValue(cmd, "@cookbookID", id);
            SQLUtility.ExecuteSQL(cmd);
        }
        public static void Save(DataTable dtCookbook)
        {
            if (dtCookbook.Rows.Count == 0)
            {
                throw new Exception("cannot call cookbook save method becasue there are no rows in the table");
            }
            DataRow r = dtCookbook.Rows[0];
            SQLUtility.SaveDataRow(r, "CookbookUpdate");
        }

        public static int AutoCreateCookbook(int UsersID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("CookbookAutoCreate");
            SQLUtility.SetParamValue(cmd, "@UsersID", UsersID);

            // Set up only the needed output parameter
            if (cmd.Parameters.Contains("@CookbookID"))
            {
                cmd.Parameters["@CookbookID"].Direction = ParameterDirection.Output;
            }
            else
            {
                SqlParameter outputParam = new SqlParameter("@CookbookID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

            }
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;


            // Execute the stored procedure
            SQLUtility.ExecuteSQL(cmd);

            // Return the generated CookbookID
            return (int)cmd.Parameters["@CookbookID"].Value;
        }
    }
}
