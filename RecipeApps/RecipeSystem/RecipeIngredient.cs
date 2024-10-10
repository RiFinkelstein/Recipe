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
    public class RecipeIngredient
    {
        public static DataTable LoadByRecipeID(int recipeID)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeIngredientGet");
            cmd.Parameters["@recipeID"].Value= recipeID;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveTable(DataTable dt, int recipeID)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["recipeID"] = recipeID;
            }
            SQLUtility.SaveDataTable(dt, "RecipeIngredientupdate");
        }

        public static void Delete(int RecipeIngredientID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeIngredientdelete");
            cmd.Parameters["@RecipeIngredientID"].Value = RecipeIngredientID;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
