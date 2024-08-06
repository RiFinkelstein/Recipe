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
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
            DBManager.setConnectionString("Server=tcp:rfinkelstein.database.windows.net,1433;Initial Catalog=HeartyHealthDB;Persist Security Info=False;User ID=Rfinkelstein;Password=#Perlman6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");
        }

        [Test]
        [TestCase("sam", 12, "1800-01-01", "1800-02-01", "1800-04-01")]
        public void InsertNewRecipe(string RecipeName, int Calories, string draftedDateStr, string publishedDateStr, string archivedDateStr)
        {
            // Convert string dates to DateTime
            DateTime DraftedDate = DateTime.Parse(draftedDateStr);
            DateTime PublishedDate = DateTime.Parse(publishedDateStr);
            DateTime ArchivedDate = DateTime.Parse(archivedDateStr);


            // Create a new DataTable to hold the recipe data
            DataTable dt = Recipe.Load(0);
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);

            dt.Columns["usersid"].ReadOnly = false;
            dt.Columns["CuisineID"].ReadOnly = false;
            dt.Columns["recipeID"].ReadOnly = false;


            int CuisineID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 CuisineID from Cuisine");
            TestContext.WriteLine("cusineid is" + CuisineID);
            int UsersID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 usersid from users");
            TestContext.WriteLine("userid is" + UsersID);


            Assume.That(CuisineID > 0, "no cuisine in database, cant do test");
            Assume.That(UsersID > 0, "no Users in database, cant do test");

            // Append current datetime to the RecipeName to ensure uniqueness
            RecipeName = RecipeName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

            r["RecipeName"] = RecipeName;
            r["Calories"] = Calories;
            r["DraftedDate"] = DraftedDate;
            r["PublishedDate"] = PublishedDate;
            r["ArchivedDate"] = ArchivedDate;
            r["usersid"] = UsersID;
            r["CuisineID"] = CuisineID;

            // Save the new recipe to the database using the existing Save method
            Recipe.Save(dt);

            // Retrieve the new RecipeID based on the unique RecipeName
            string query = $"SELECT RecipeID FROM Recipe WHERE RecipeName LIKE '%{RecipeName}%'";
            int newID = SQLUtility.GetFirstColumnFirstRowValue(query);

            // Assert that the new RecipeID is valid
            ClassicAssert.IsTrue(newID > 0, "Recipe with RecipeName = " + RecipeName + " is not found in the database.");
            TestContext.WriteLine("Recipe with " + RecipeName + " is found in the database with primary key value = " + newID);
        }


        [Test]
        [TestCase(12, "1800-01-01", "1800-02-01", "1800-04-01")]
        public void InsertNewRecipeInvalidName(int Calories, string draftedDateStr, string publishedDateStr, string archivedDateStr)
        {
            // Convert string dates to DateTime
            DateTime DraftedDate = DateTime.Parse(draftedDateStr);
            DateTime PublishedDate = DateTime.Parse(publishedDateStr);
            DateTime ArchivedDate = DateTime.Parse(archivedDateStr);


            // Create a new DataTable to hold the recipe data
            DataTable dt = Recipe.Load(0);
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);

            dt.Columns["usersid"].ReadOnly = false;
            dt.Columns["CuisineID"].ReadOnly = false;
            int CuisineID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 CuisineID from Cuisine");
            TestContext.WriteLine("cusineid is" + CuisineID);
            int UsersID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 usersid from users");
            TestContext.WriteLine("userid is" + UsersID);

            string RecipeName = SQLUtility.GetFirstColumnFirstRowValuestring("select top 1 recipename from recipe");

            Assume.That(CuisineID > 0, "no cuisine in database, cant do test");
            Assume.That(UsersID > 0, "no Users in database, cant do test");
            r["RecipeName"] = RecipeName;
            r["Calories"] = Calories;
            r["DraftedDate"] = DraftedDate;
            r["PublishedDate"] = PublishedDate;
            r["ArchivedDate"] = ArchivedDate;
            r["usersid"] = UsersID;
            r["CuisineID"] = CuisineID;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }
        

        [Test]
        public void ChangeExistingRecipeCalories()
        {
            int recipeID = getExistingRecipeID();
            Assume.That(recipeID > 0, "no recipes in database, cant do test");
            int Calories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid =" + recipeID);
            TestContext.WriteLine("calories for recipeID" + recipeID + "is " + Calories);
            Calories = Calories + 1;
            TestContext.WriteLine("change Calories" + Calories);
            DataTable dt = Recipe.Load(recipeID);
            dt.Rows[0]["calories"] = Calories;
            dt.Columns["recipeID"].ReadOnly = false;

            Recipe.Save(dt);
            int newCalories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid =" + recipeID);
            ClassicAssert.IsTrue(newCalories == Calories, "calroeis for recipe (" + recipeID + ") = " + newCalories);
            TestContext.WriteLine("calories for recipe(" + recipeID + ") =" + Calories);
        }

        [Test]
        public void ChangeExistingRecipeinvalidCalories()
        {
            int recipeID = getExistingRecipeID();
            int calories = -5;
            Assume.That(recipeID > 0, "no recipes in database, cant do test");

            TestContext.WriteLine("change termstart year" + calories);
            DataTable dt = Recipe.Load(recipeID);
            dt.Rows[0]["calories"] = calories;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeExistingDraftedDate()
        {
            // Get an existing RecipeID from the database
            int recipeID = getExistingRecipeID();
            Assume.That(recipeID > 0, "No recipe in the database, can't perform the test");
            // Retrieve the current drafteddate using the RecipeID
            DateTime DraftedDate = SQLUtility.GetFirstColumnFirstRowValueDate("SELECT DraftedDate FROM recipe WHERE RecipeID = " + recipeID);
            TestContext.WriteLine("Drafted date for RecipeID " + recipeID + " is " + DraftedDate);
            DateTime NewDraftedDate = DraftedDate.AddDays(5);
            TestContext.WriteLine("Changing new drafted date to " + NewDraftedDate);
            // Load the recipe data into a DataTable 
            DataTable dt = Recipe.Load(recipeID);
            // Update the recipe name in the DataTable
            dt.Rows[0]["DraftedDate"] = NewDraftedDate;
            dt.Columns["recipeID"].ReadOnly = false;

            // Save the updated DataTable back to the database
            Recipe.Save(dt);
            // Retrieve the updated recipe name from the database
            DateTime updatedDraftedDate = SQLUtility.GetFirstColumnFirstRowValueDate("SELECT DraftedDate FROM recipe WHERE RecipeID = " + recipeID);
            // Assert that the updated recipe name matches the expected new recipe name
            ClassicAssert.IsTrue(updatedDraftedDate == NewDraftedDate, "Recipe name for RecipeID (" + recipeID + ") is " + updatedDraftedDate);
            // Output the final recipe name
            TestContext.WriteLine("Recipe name for RecipeID (" + recipeID + ") is now " + NewDraftedDate);
        }

        [Test]
        public void deleteRecipe()
        {
            string sql = @"SELECT TOP 1 r.RecipeID 
FROM recipe r 
LEFT JOIN RecipeIngredient ri 
ON r.RecipeID = ri.RecipeID 
LEFT JOIN Directions d 
ON r.RecipeID = d.RecipeID 
LEFT JOIN CourseMealRecipe cmr 
ON r.RecipeID = cmr.RecipeID 
LEFT JOIN CookbookRecipe cbr 
ON r.RecipeID = cbr.RecipeID 
WHERE ri.RecipeID IS NULL 
AND d.RecipeID IS NULL 
AND cmr.RecipeID IS NULL 
AND cbr.RecipeID IS NULL 
AND (r.status = 'drafted' OR DATEDIFF(day, r.ArchivedDate, GETDATE()) > 30)";

            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeID = 0;

            if (dt.Rows.Count > 0)
            {
                recipeID = (int)dt.Rows[0]["recipeID"];
            }
            Assume.That(recipeID > 0, "no recipes in database, cant do test");
            TestContext.WriteLine("existing recipe with recipe ID= " + recipeID);
            Recipe.Delete(dt);
            DataTable dtAfterDelete = Recipe.Load(recipeID);
            ClassicAssert.IsTrue(dtAfterDelete.Rows.Count == 0, "record with RecipeID " + recipeID + " exists in db");
            TestContext.WriteLine("record with recipeID: " + recipeID + "does not exist in DB");
        }

        [Test]
        public void deleteRecipeInvalid()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT TOP 1 r.RecipeID FROM recipe r JOIN RecipeIngredient ri ON r.RecipeID = ri.RecipeID JOIN Directions d ON r.RecipeID = d.RecipeID JOIN CourseMealRecipe cmr ON r.RecipeID = cmr.RecipeID JOIN CookbookRecipe cbr ON r.RecipeID = cbr.RecipeID");
            int recipeID = 0;
            if (dt.Rows.Count > 0)
            {
                recipeID = (int)dt.Rows[0]["recipeID"];
            }
            Assume.That(recipeID > 0, "no recipes in database, cant do test");
            TestContext.WriteLine("existing recipe with recipe ID= " + recipeID);
            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void deleteRecipeInvalidbecasueofBusinessrule()
        {
            string sql = @"
                        SELECT TOP 1 r.RecipeID 
                        FROM recipe r JOIN RecipeIngredient ri 
                        ON r.RecipeID = ri.RecipeID 
                        JOIN Directions d 
                        ON r.RecipeID = d.RecipeID 
                        JOIN CourseMealRecipe cmr 
                        ON r.RecipeID = cmr.RecipeID 
                        JOIN CookbookRecipe cbr 
                        ON r.RecipeID = cbr.RecipeID
                        where
                        (r.Status = 'published' or DATEDIFF(day, r.ArchivedDate, GETDATE())<30)
                        ";
            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeID = 0;
            if (dt.Rows.Count > 0)
            {
                recipeID = (int)dt.Rows[0]["recipeID"];
            }
            Assume.That(recipeID > 0, "no recipes that are currently published and there are no recipes that are archived more than 30 days, cant do test");
            TestContext.WriteLine("existing recipe with recipe ID= " + recipeID);
            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }


        [Test]
        public void SearchRecipes()
        {
            string criteria = "a";
            int num = SQLUtility.GetFirstColumnFirstRowValue("select total= count (*) from recipe where recipename like '%" + criteria + "%'");
            Assume.That(num > 0, "there are no recipes that match the search for " + num);
            TestContext.WriteLine(num + "recipe that match " + criteria);
            TestContext.WriteLine("ensure that recipe search returns " + num + "rows");

            DataTable dt = Recipe.SearchRecipe(criteria);

            int results = dt.Rows.Count;

            ClassicAssert.IsTrue(results == num, "results of recipes search does not match number of recipes" + results + "<>" + num);
            TestContext.WriteLine("number of rows returned by recipes search is " + results);

        }


        [Test]
        public void LoadRecipe()
        {
            int recipeID = getExistingRecipeID();
            Assume.That(recipeID > 0, "no recipes in database, cant do test");
            TestContext.WriteLine("existing recipe with ID= " + recipeID);
            TestContext.WriteLine("ensure that app loads recipe " + recipeID);
            DataTable dt = Recipe.Load(recipeID);
            int loadedID = (int)dt.Rows[0]["recipeID"];
            ClassicAssert.IsTrue(loadedID == recipeID, (int)dt.Rows[0]["recipeID"] + "<>" + recipeID);
            TestContext.WriteLine("loaded recipe (" + loadedID + ")");
        }

        [Test]
        public void GetListOfCuisines()
        {
            int CusineCount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from Cuisine");
            Assume.That(CusineCount > 0, "no cuisines in database, cant do test");
            TestContext.WriteLine("number of rows in DB= " + CusineCount);
            TestContext.WriteLine("Ensure the num of rows return by app matches " + CusineCount);
            DataTable dt = Recipe.GetCuisineList();
            ClassicAssert.IsTrue(dt.Rows.Count == CusineCount, "num rows return by app (" + dt.Rows.Count + ")<> " + CusineCount);
            TestContext.WriteLine("number of rows in cusine retruned byt the app " + dt.Rows.Count);
        }

        [Test]
        public void GetListOfUsers()
        {
            int UsersCount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from Users");
            Assume.That(UsersCount > 0, "no Users in database, cant do test");
            TestContext.WriteLine("number of rows in DB= " + UsersCount);
            TestContext.WriteLine("Ensure the num of rows return by app matches " + UsersCount);
            DataTable dt = Recipe.GetUserList();
            ClassicAssert.IsTrue(dt.Rows.Count == UsersCount, "num rows return by app (" + dt.Rows.Count + ")<> " + UsersCount);
            TestContext.WriteLine("number of rows in users retruned byt the app " + dt.Rows.Count);
        }
        private int getExistingRecipeID()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeID from recipe");

        }
    }
}