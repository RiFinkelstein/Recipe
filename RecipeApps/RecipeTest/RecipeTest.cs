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
            int recipeID = getExistingRecipeID();
            Assume.That(recipeID > 0, "no recipe in database, cant do test");
            string recipeName = SQLUtility.GetFirstColumnFirstRowValue("select Recipename from recipe where recipeID =" + recipeID).ToString();
            TestContext.WriteLine("recipename for recipeID" + recipeID + "is " + recipeName);
            recipeName = recipeName + "AA";
            TestContext.WriteLine("change recipename" + recipeName);
            DataTable dt = Recipe.Load(recipeID);
            dt.Rows[0]["RecipeName"] = recipeName;
            Recipe.Save(dt);
            string NewRecipeName = SQLUtility.GetFirstColumnFirstRowValue("select recipeName from recipe where recipeID =" + recipeID).ToString();
            ClassicAssert.IsTrue(NewRecipeName == recipeName, "recipename for president (" + recipeID + ") = " + NewRecipeName);
            TestContext.WriteLine("recipe name for recipe(" + recipeID + ") =" + recipeName);
        }
        

        [Test]
        public void deleteRecipe()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 recipeid from recipe");
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