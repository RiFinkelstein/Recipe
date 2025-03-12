global using CPUFramework;
using NUnit.Framework;
using RecipeSystem;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using NUnit.Framework.Legacy;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Extensibility;

namespace RecipeTest
{
    internal class ConstraintTest
    {
            
        [SetUp]
        public void Setup()
        {

            DBManager.setConnectionString("Server=tcp:rfinkelstein.database.windows.net,1433;Initial Catalog=HeartyHealthDB;Persist Security Info=False;User ID=Rfinkelstein;Password=#Perlman6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");
        }

        //users contraint tests
        [Test]
        public void InsertBlankUsersFirstName()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Users WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["UsersFirstName"] = "";  // Violates check constraint
            r["UsersLastName"] = "Doe";
            r["UsersName"] = "jdoe123";

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "UsersUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }

        [Test]
        public void InsertDuplicateUsersName()
        {
            string existingUserName = SQLUtility.GetFirstColumnFirstRowValuestring("SELECT TOP 1 UsersName FROM Users");
            Assume.That(!string.IsNullOrEmpty(existingUserName), "No existing users in database.");

            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Users WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["UsersFirstName"] = "John";
            r["UsersLastName"] = "Doe";
            r["UsersName"] = existingUserName;  // Violates UNIQUE constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "UsersUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }


        //ingredient contraint tests

        [Test]
        public void InsertBlankIngredientName()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Ingredient WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["IngredientName"] = "";  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "IngredientUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }

        [Test]
        public void InsertDuplicateIngredientName()
        {
            string existingIngredient = SQLUtility.GetFirstColumnFirstRowValuestring("SELECT TOP 1 IngredientName FROM Ingredient");
            Assume.That(!string.IsNullOrEmpty(existingIngredient), "No existing ingredients in database.");

            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Ingredient WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["IngredientName"] = existingIngredient;  // Violates UNIQUE constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "IngredientUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }



        //cusine contraint tests
        [Test]
        public void InsertBlankCuisineName()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Cuisine WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["CuisineName"] = "";  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt , "CuisineUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }
        [Test]
        public void InsertDuplicateCuisineName()
        {
            string existingCuisine = SQLUtility.GetFirstColumnFirstRowValuestring("SELECT TOP 1 CuisineName FROM Cuisine");
            Assume.That(!string.IsNullOrEmpty(existingCuisine), "No existing cuisines in database.");

            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Cuisine WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["CuisineName"] = existingCuisine;  // Violates UNIQUE constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "CuisineUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }

        //recipe contraint tests
        [Test]
        public void InsertBlankRecipeName()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Recipe WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["RecipeName"] = "";  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "RecipeUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }


        [Test]
        public void InsertNullRecipeName()
        {
            DataTable dt = Recipe.Load(0);
            DataRow r = dt.Rows.Add();

            int CuisineID = SQLUtility.GetFirstColumnFirstRowValue("SELECT TOP 1 CuisineID FROM Cuisine");
            int UsersID = SQLUtility.GetFirstColumnFirstRowValue("SELECT TOP 1 UsersID FROM Users");

            Assume.That(CuisineID > 0 && UsersID > 0, "No cuisine or users in database, cannot test.");

            r["RecipeName"] = DBNull.Value; // Violating NOT NULL
            r["Calories"] = 300;
            r["DraftedDate"] = DateTime.Now;
            r["PublishedDate"] = DateTime.Now.AddDays(1);
            r["ArchivedDate"] = DateTime.Now.AddDays(10);
            r["UsersID"] = UsersID;
            r["CuisineID"] = CuisineID;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }
        [Test]
        public void InsertNegativeCalories()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Recipe WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["Calories"] = -10;  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "RecipeUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }
        [Test]
        public void InsertDraftedDateInFuture()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Recipe WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["DraftedDate"] = DateTime.Now.AddDays(10);  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "RecipeUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }
        

        [Test]
        public void InsertDuplicateRecipeName()
        {
            string existingRecipeName = SQLUtility.GetFirstColumnFirstRowValuestring("SELECT TOP 1 RecipeName FROM Recipe");
            Assume.That(!string.IsNullOrEmpty(existingRecipeName), "No existing recipe names in database, cannot test.");

            DataTable dt = Recipe.Load(0);
            DataRow r = dt.Rows.Add();

            int CuisineID = SQLUtility.GetFirstColumnFirstRowValue("SELECT TOP 1 CuisineID FROM Cuisine");
            int UsersID = SQLUtility.GetFirstColumnFirstRowValue("SELECT TOP 1 UsersID FROM Users");

            Assume.That(CuisineID > 0 && UsersID > 0, "No cuisine or users in database, cannot test.");

            r["RecipeName"] = existingRecipeName; // Using existing name to violate unique constraint
            r["Calories"] = 250;
            r["DraftedDate"] = DateTime.Now;
            r["PublishedDate"] = DateTime.Now.AddDays(1);
            r["ArchivedDate"] = DateTime.Now.AddDays(10);
            r["UsersID"] = UsersID;
            r["CuisineID"] = CuisineID;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }

        [Test]
        public void InsertArchivedDateBeforePublishedDate()
        {
            DataTable dt = Recipe.Load(0);
            DataRow r = dt.Rows.Add();

            int CuisineID = SQLUtility.GetFirstColumnFirstRowValue("SELECT TOP 1 CuisineID FROM Cuisine");
            int UsersID = SQLUtility.GetFirstColumnFirstRowValue("SELECT TOP 1 UsersID FROM Users");

            Assume.That(CuisineID > 0 && UsersID > 0, "No cuisine or users in database, cannot test.");

            r["RecipeName"] = "TestArchivedBeforePublished_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            r["Calories"] = 250;
            r["DraftedDate"] = DateTime.Now;
            r["PublishedDate"] = DateTime.Now.AddDays(5);
            r["ArchivedDate"] = DateTime.Now.AddDays(2); // Invalid: Archived before Published
            r["UsersID"] = UsersID;
            r["CuisineID"] = CuisineID;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }


        //measurment contraint test

        [Test]
        public void InsertBlankMeasurementName()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Measurement WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["MeasurementName"] = "";  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt , "MeasurementUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }

        //recipeingriedient contraint test
        [Test]
        public void InsertNegativeAmount()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM RecipeIngredient WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["Amount"] = -1;  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt , "RecipeIngredientUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }

        //directions contraint test
        [Test]
        public void InsertBlankDirection()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Directions WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["Direction"] = "";  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt , "DirectionsUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }

        //cookbook contraint test
        [Test]
        public void InsertNegativeCookbookPrice()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM Cookbook WHERE 1=0");
            DataRow r = dt.Rows.Add();

            r["Price"] = -5;  // Violates check constraint

            Exception ex = Assert.Throws<Exception>(() => SQLUtility.SaveDataTable(dt, "CookbookUpdate"));
            TestContext.WriteLine("Error Message: " + ex.Message);
        }



    }
}
