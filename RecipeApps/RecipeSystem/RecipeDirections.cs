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

        public static void Save(DataTable dtRecipeDirections, int RecipeID)
        {
            if (dtRecipeDirections.Rows.Count == 0)
            {
                throw new Exception("cannot call recipe save method becasue there are no rows in the table");
            }
            foreach (DataRow r in dtRecipeDirections.Rows)
           {
                r["RecipeID"] = RecipeID;
                SQLUtility.SaveDataRow(r, "RecipeDirectionsUpdate");
            }
        }
        public static void Delete(int DirectionsID)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeDirectionsDelete");
            cmd.Parameters["@DirectionsID"].Value = DirectionsID;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
