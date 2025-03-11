using CPUFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            SqlCommand cmd = SQLUtility.GetSqlcommand("usersget");
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
            SQLUtility.SaveDataRow(r, "RecipeUpdate");
        }

        public static void Delete(DataTable dtRecipe)
        {
            int id = (int)dtRecipe.Rows[0]["recipeID"];
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@recipeid", id);

            cmd.Parameters["@message"].Direction = ParameterDirection.Output;


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
                SqlParameter clonedRecipeParam = new SqlParameter("@ClonedRecipeID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(clonedRecipeParam);
            }
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;

            // Execute the stored procedure
            SQLUtility.ExecuteSQL(cmd);

            object RecipeIDValue = cmd.Parameters["@ClonedRecipeID"].Value;

            if (RecipeIDValue == DBNull.Value)
            {
                // Fetch the message from the stored procedure output
                string message = cmd.Parameters["@message"].Value.ToString();
                throw new Exception(message ?? "Recipe could not be created");
            }


            // Return the generated RecipeID
            return (int)RecipeIDValue;
        }


    }
}
