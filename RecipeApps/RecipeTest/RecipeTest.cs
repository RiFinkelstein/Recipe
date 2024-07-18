global using CPUFramework;
using NUnit.Framework;
using RecipeSystem;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using NUnit.Framework.Legacy;

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
        public void ChangeExistingRecipeName()
        {
            // Get an existing RecipeID from the database
            int recipeID = getExistingRecipeID();
            Assume.That(recipeID > 0, "No recipe in the database, can't perform the test"); 
            // Retrieve the current recipe name using the RecipeID
            string recipeName = SQLUtility.GetFirstColumnFirstRowValue("SELECT RecipeName FROM recipe WHERE RecipeID = " + recipeID).ToString(); 
            TestContext.WriteLine("Recipe name for RecipeID " + recipeID + " is " + recipeName); 
            // Modify the recipe name by appending "AA" 
            string newRecipeName = recipeName + "AA";
            TestContext.WriteLine("Changing recipe name to " + newRecipeName); 
            // Load the recipe data into a DataTable 
            DataTable dt = Recipe.Load(recipeID); 
            // Update the recipe name in the DataTable
            dt.Rows[0]["RecipeName"] = newRecipeName; 
            // Save the updated DataTable back to the database
            Recipe.Save(dt); 
            // Retrieve the updated recipe name from the database
            string updatedRecipeName = SQLUtility.GetFirstColumnFirstRowValue("SELECT RecipeName FROM recipe WHERE RecipeID = " + recipeID).ToString(); 
            // Assert that the updated recipe name matches the expected new recipe name
            ClassicAssert.IsTrue(updatedRecipeName == newRecipeName, "Recipe name for RecipeID (" + recipeID + ") is " + updatedRecipeName); 
            // Output the final recipe name
            TestContext.WriteLine("Recipe name for RecipeID (" + recipeID + ") is now " + newRecipeName);  
        }


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