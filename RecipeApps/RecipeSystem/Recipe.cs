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
    public class Recipe
    {
        public static DataTable SearchRecipe(string RecipeName)
        {
                DataTable dt = new();
                SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeGet");
                SQLUtility.SetParamValue(cmd, "@recipename", RecipeName);
                dt = SQLUtility.GetDataTable(cmd);
                return dt;
        }

        public static DataTable Load(int RecipeID)
        {

            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@recipeID", RecipeID);
            dt = SQLUtility.GetDataTable(cmd);

            return dt;

        }
        
        public static DataTable GetUserList()
        {

            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("userget");
            SQLUtility.SetParamValue(cmd, "@all", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
        

        public static DataTable GetCuisineList()
        {

            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("Cuisineget");
            SQLUtility.SetParamValue(cmd, "@all", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dtRecipe)
        {
            if (dtRecipe.Rows.Count == 0)
            {
                throw new Exception("cannot call recipe save method becasue there are no rows in the table");
            }
            DataRow r = dtRecipe.Rows[0];
            SQLUtility.SaveDataRow(r, "recipeupdate");
        }

        public static void Delete(DataTable dtRecipe)
        {
            int id = (int)dtRecipe.Rows[0]["recipeID"];
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@recipeid", id);
            SQLUtility.ExecuteSQL(cmd);
        }
        public static string GetRecipeDescription(DataTable dtRecipe)
        {
            string value = "New Recipe";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "recipeID");
            if (pkvalue > 0)
            {
                value = "Recipe" + " - " + SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "recipename");
            }

            return value;
        }
        public static int CloneRecipe(int originalRecipeID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeClone");
            SQLUtility.SetParamValue(cmd, "@OriginalRecipeID", originalRecipeID);

            if (cmd.Parameters.Contains("@ClonedRecipeID"))
            {
                cmd.Parameters["@ClonedRecipeID"].Direction = ParameterDirection.Output;
            }
            else
            {
                SqlParameter outputParam = new SqlParameter("@ClonedRecipeID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

            }
            SQLUtility.ExecuteSQL(cmd);
            return (int)cmd.Parameters["@ClonedRecipeID"].Value;

        }

    }
}
