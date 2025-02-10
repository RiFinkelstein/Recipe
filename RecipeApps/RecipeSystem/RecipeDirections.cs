using CPUFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class RecipeDirections
    {
        public static DataTable LoadByRecipeID(int RecipeID)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeDirectionsGet");
            cmd.Parameters["@RecipeID"].Value = RecipeID;
            
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
        public static void SaveTable(DataTable dt, int recipeID)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["recipeID"] = recipeID;
            }
            SQLUtility.SaveDataTable(dt, "DirectionsUpdate");
        }
        public static void Delete(int DirectionsID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeDirectionsDelete");
            cmd.Parameters["@DirectionsID"].Value = DirectionsID;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
