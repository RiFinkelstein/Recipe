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
    public class RecipeSteps
    {
        public static DataTable LoadByRecipeID(int recipeID)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeStepsGet");
            cmd.Parameters["@recipeID"].Value = recipeID;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveSteps(DataTable dtrecipe, int directionsID)
        {
            if (dtrecipe.Rows.Count == 0)
            {
                throw new Exception("cannot call RecipeStepsUpdate method becasue there are no rows in the table");
            }
            foreach (DataRow r in dtrecipe.Rows)
            {
                if(r.RowState== DataRowState.Added || r.RowState== DataRowState.Modified)
                {
                    SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeStepsUpdate");
                    cmd.Parameters["@directionsID"].Value = directionsID;
                    SQLUtility.ExecuteSQL(cmd);
                    //SQLUtility.SaveDataRow(r, "RecipeStepsUpdate");

                }
            }
            //DataRow r = dtrecipe.Rows[0];
        }
        public static void Delete(int RecipeStepsID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeStepsDelete");
            cmd.Parameters["@directionsID"].Value = RecipeStepsID;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
