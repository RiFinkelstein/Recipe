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
    public class CookbookRecipe
    {
        public static DataTable LoadByCookbookID(int cookbookID)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("CookbookRecipeGet");
            cmd.Parameters["@cookbookID"].Value = cookbookID;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
        
        public static void SaveTable(DataTable dt, int cookbookID)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["cookbookID"] = cookbookID;
            }
            SQLUtility.SaveDataTable(dt, "CookbookRecipeUpdate");

        }

        public static void Delete(int CookbookRecipeID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("CookbookRecipeDelete");
            cmd.Parameters["@CookbookRecipeID"].Value = CookbookRecipeID;
            SQLUtility.ExecuteSQL(cmd);
        }

        public static DataTable GetRecipeList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("recipeget");
            SQLUtility.SetParamValue(cmd, "@all", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
    }
}
