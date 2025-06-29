using CPUFramework;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizIngredient: bizObject <bizIngredient>
    {
        private int _ingredientID;
        private string _ingredientname;

        public List<bizIngredient> Search(string ingredientnameval)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand(this.GetSprcoName);
            SQLUtility.SetParamValue(cmd, "IngredientName", ingredientnameval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int IngredientID
        {
            get { return _ingredientID; }
            set
            {
                _ingredientID = value;
                InvokePropertyChanged();
            }
        }

        public string IngredientName
        {
            get { return _ingredientname; }
            set
            {
                _ingredientname = value;
                InvokePropertyChanged();
            }
        }
    }
}
