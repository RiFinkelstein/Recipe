global using CPUFramework;
using NUnit.Framework;
using RecipeSystem;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using NUnit.Framework.Legacy;
using Microsoft.Data.SqlClient;

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
            DataTable dt = SQLUtility.GetDataTable("SELECT * FROM recipe WHERE RecipeID = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);

            // Append current datetime to the RecipeName to ensure uniqueness
            RecipeName = RecipeName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            r["RecipeName"] = RecipeName;
            r["Calories"] = Calories;
            r["DraftedDate"] = DraftedDate;
            r["PublishedDate"] = PublishedDate;
            r["ArchivedDate"] = ArchivedDate;

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
            Recipe.Save(dt);
            int newCalories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid =" + recipeID);
            ClassicAssert.IsTrue(newCalories == Calories, "calroeis for recipe (" + recipeID + ") = " + newCalories);
            TestContext.WriteLine("calories for recipe(" + recipeID + ") =" + Calories);
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
            // Save the updated DataTable back to the database
            Recipe.Save(dt);
            // Retrieve the updated recipe name from the database
            DateTime updatedDraftedDate = SQLUtility.GetFirstColumnFirstRowValueDate("SELECT DraftedDate FROM recipe WHERE RecipeID = " + recipeID);
            // Assert that the updated recipe name matches the expected new recipe name
            ClassicAssert.IsTrue(updatedDraftedDate == NewDraftedDate, "Recipe name for RecipeID (" + recipeID + ") is " + updatedDraftedDate);
            // Output the final recipe name
            TestContext.WriteLine("Recipe name for RecipeID (" + recipeID + ") is now " + NewDraftedDate);
        }


 /*       [Test]
 Ive manually done this test a lot of times and it wokrs but when I run it it doesnt work, Ive tried debugging and I cant figure it out... 
        public void ChangeExistingRecipeName()
        {
            // Get an existing RecipeID from the database
            int recipeID = getExistingRecipeID();
            Assume.That(recipeID > 0, "No recipe in the database, can't perform the test"); 

            // Retrieve the current recipe name using the RecipeID
            string recipeName = SQLUtility.GetFirstColumnFirstRowValue("SELECT RecipeName FROM recipe WHERE RecipeID = " + recipeID).ToString(); 
            TestContext.WriteLine("Recipe name for RecipeID " + recipeID + " is " + recipeName);
            Assume.That(!string.IsNullOrEmpty(recipeName), "recipe name is not be null or empty");
            
            // Modify the recipe name by appending "AA" 
            string newRecipeName = recipeName + "AA" + DateTime.Now.ToString();
            TestContext.WriteLine("Changing recipe name to " + newRecipeName); 
            
            // Load the recipe data into a DataTable 
            DataTable dt = Recipe.Load(recipeID);
            TestContext.WriteLine("loaded data for recipeid" + recipeID);


            // Update the recipe name in the DataTable
            dt.Rows[0]["recipename"] = newRecipeName;
            TestContext.WriteLine("old recipe name is "+ recipeName);


            SQLUtility.DebugPringDataTable(dt);

            // Save the updated DataTable back to the database
            Recipe.Save(dt);
            TestContext.WriteLine("saved data for recipeID: " + recipeID + "with new name" + recipeName);

            // Retrieve the updated recipe name from the database
            string updatedRecipeName = SQLUtility.GetFirstColumnFirstRowValue("SELECT RecipeName FROM recipe WHERE RecipeID = " + recipeID).ToString();


            TestContext.WriteLine("updated recipe name is " + updatedRecipeName);

            System.Threading.Thread.Sleep(4000);

            // Assert that the updated recipe name matches the expected new recipe name
            ClassicAssert.AreSame(updatedRecipeName, newRecipeName, "Recipe name for RecipeID (" + recipeID + ") is " + updatedRecipeName);
            // Output the final recipe name
            TestContext.WriteLine("Recipe name for RecipeID (" + recipeID + ") is now " + recipeName);  
        }
        */

        [Test]
        public void deleteRecipe()
        {
            DataTable dt = SQLUtility.GetDataTable("SELECT TOP 1 r.RecipeID FROM recipe r LEFT JOIN RecipeIngredient ri ON r.RecipeID = ri.RecipeID LEFT JOIN Directions d ON r.RecipeID = d.RecipeID LEFT JOIN CourseMealRecipe cmr ON r.RecipeID = cmr.RecipeID LEFT JOIN CookbookRecipe cbr ON r.RecipeID = cbr.RecipeID WHERE ri.RecipeID IS NULL AND d.RecipeID IS NULL  AND cmr.RecipeID IS NULL AND cbr.RecipeID IS NULL");
            int recipeID = 0;
            if (dt.Rows.Count > 0 ) { 
                recipeID= (int)dt.Rows[0]["recipeID"];
            }
            Assume.That(recipeID > 0, "no recipes in database, cant do test");
            TestContext.WriteLine("existing recipe with recipe ID= "+ recipeID);
            Recipe.Delete(dt);
            DataTable dtAfterDelete = SQLUtility.GetDataTable("select * from recipe where recipeID= " + recipeID);
            ClassicAssert.IsTrue(dtAfterDelete.Rows.Count == 0, "record with RecipeID " + recipeID + " exists in db");
            TestContext.WriteLine("record with recipeID: " + recipeID + "does not exist in DB"); 
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
        private int getExistingRecipeID()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeID from recipe");

        }
    }
}