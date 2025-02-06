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
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeStepsGet");
            cmd.Parameters["@RecipeID"].Value = RecipeID;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveTable(DataTable dt, int recipeID)
        {
            dt.Columns["RecipeID"].ReadOnly = false;
            //dt.Columns["DirectionsID"].ReadOnly = false;
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["recipeID"] = recipeID;
            }

            Debug.Print($"Saving {dt.Rows.Count} rows for RecipeID {recipeID}");
            foreach (DataRow row in dt.Rows)
            {
                Debug.Print($"DirectionsID: {row["DirectionsID"]}, RecipeID: {row["RecipeID"]}, StepNumber: {row["StepNumber"]}, Direction: {row["Direction"]}");
            }

            SQLUtility.SaveDataTable(dt, "RecipeStepsUpdate");
            Debug.Print("SaveTable called");

        }
        public static void Delete(int RecipeStepsID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeStepsDelete");
            cmd.Parameters["@DirectionsID"].Value = RecipeStepsID;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
