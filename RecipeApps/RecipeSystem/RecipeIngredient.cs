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
    }
}
