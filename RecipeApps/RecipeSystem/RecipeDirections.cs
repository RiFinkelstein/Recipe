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
    public class RecipeDirections
    {
        public static DataTable LoadByRecipeID(int recipeID)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeStepsGet");
            cmd.Parameters["@recipeID"].Value = recipeID;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }


        public static void SaveTable(DataTable dt, int recipeID)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                dt.Columns["recipeID"].ReadOnly = false;
                r["recipeID"] = recipeID;
            }
            SQLUtility.SaveDataTable(dt, "RecipeStepsUpdate");
        }
        public static void Delete(int RecipeStepsID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeStepsDelete");
            cmd.Parameters["@directionsID"].Value = RecipeStepsID;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
