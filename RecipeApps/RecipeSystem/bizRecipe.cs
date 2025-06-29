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
    public class bizRecipe : bizObject <bizRecipe>
    {
        public bizRecipe() { }
        private int _recipeid;
        private int _cuisineid;
        private int _usersid;
        private string _recipename;
        private int _calories;
        private DateTime _drafteddate;
        private DateTime? _publisheddate;
        private DateTime? _archiveddate;


        public List<bizRecipe> Search(string recipenameval)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand(this.GetSprcoName);
            SQLUtility.SetParamValue(cmd, "RecipeName", recipenameval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int RecipeID
        {
            get { return _recipeid; }
            set
            {
                if (_recipeid != value)
                {
                    _recipeid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int CuisineID
        {
            get { return _cuisineid; }
            set
            {
                if (_cuisineid != value)
                {
                    _cuisineid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int UsersID
        {
            get { return _usersid; }
            set
            {
                if (_usersid != value)
                {
                    _usersid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string RecipeName
        {
            get { return _recipename; }
            set
            {
                if (_recipename != value)
                {
                    _recipename = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int Calories
        {

            get { return _calories; }
            set
            {
                if (_calories != value)
                {
                    _calories = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime DraftedDate
        {
            get { return _drafteddate; }
            set
            {
                if (_drafteddate != value)
                {
                    _drafteddate = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime? PublishedDate
        {
            get { return _publisheddate; }
            set
            {
                if (_publisheddate != value)
                {
                    _publisheddate = value;
                    InvokePropertyChanged();
                }
            }
        } 
        public DateTime? ArchivedDate
        {
            get { return _archiveddate; }
            set
            {
                if (_archiveddate != value)
                {
                    _archiveddate = value;
                    InvokePropertyChanged();
                }
            }
        }

    }
}
