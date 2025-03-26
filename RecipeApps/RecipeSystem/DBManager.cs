using CPUFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class DBManager
    {
        public static void SetConnectionString(string connectionstring, bool tryopen, string userID = "", string password = "")
        {
            SQLUtility.SetConnectionString(connectionstring, tryopen, userID, password);
        }
    }
}