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

                cmd.Parameters["@recipename"].Value = RecipeName;

                dt = SQLUtility.GetDataTable(cmd);

                return dt;
        }

        public static DataTable Load(int RecipeID)
        {
            string sql = "select * from recipe r where r.recipeID= " + RecipeID.ToString();
            return SQLUtility.GetDataTable(sql);
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
                    $"Calories= '{r["Calories"]}',",
                    $"DraftedDate= '{r["DraftedDate"]}',",
                    $"PublishedDate= nullif('{r["PublishedDate"]}', ''),",
                    $"ArchivedDate= nullif('{r["ArchivedDate"]}', '')",
                    $"where recipeID=  {r["recipeID"]}");
            }
            else
            {
                sql = "insert recipe(UsersID, CuisineID, RecipeName, Calories, DraftedDate,PublishedDate, ArchivedDate)";
                sql += $"select (Select u.usersID from users U WHERE UserName = 'JGreen'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), '{r["RecipeName"]}', {r["Calories"]}, '{r["DraftedDate"]}',   nullif('{r["PublishedDate"]}', ''),  nullif('{r["ArchivedDate"]}', '')";
            }
            Debug.Print("-----------");
            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtRecipe)
        {
            int id = (int)dtRecipe.Rows[0]["recipeID"];
            string sql = "delete recipe where recipeID=" + id;
            SQLUtility.ExecuteSQL(sql);
            Debug.Print(sql);
        }

       

    }
}
