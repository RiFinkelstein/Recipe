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
            SQLUtility.DebugPringDataTable(dtRecipe);
            DataRow r = dtRecipe.Rows[0];
            int id = (int)r["recipeID"];
            string sql = "";
            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
                    $"RecipeName= '{r["RecipeName"]}',",
                    $"UsersID= '{r["UsersID"]}',",
                    $"CuisineID= '{r["CuisineID"]}',",
                    $"Calories= '{r["Calories"]}',",
                    $"DraftedDate= '{r["DraftedDate"]}',",
                    $"PublishedDate= nullif('{r["PublishedDate"]}', ''),",
                    $"ArchivedDate= nullif('{r["ArchivedDate"]}', '')",
                    $"where recipeID=  {r["recipeID"]}");
            }
            else
            {
                sql = "insert recipe(UsersID, CuisineID, RecipeName, Calories, DraftedDate,PublishedDate, ArchivedDate)";
                sql += $"select '{r["UsersID"]}', '{r["CuisineID"]}',  '{r["RecipeName"]}', {r["Calories"]}, '{r["DraftedDate"]}',   nullif('{r["PublishedDate"]}', ''),  nullif('{r["ArchivedDate"]}', '')";
            }
            Debug.Print("-----------");
            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtRecipe)
        {
            int id = (int)dtRecipe.Rows[0]["recipeID"];
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@recipeid", id);
            SQLUtility.ExecuteSQL(cmd);
        }

    }
}
