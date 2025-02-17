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
                            AND (r.recipestatus = 'drafted' OR DATEDIFF(day, r.ArchivedDate, GETDATE()) > 30)";
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
                            ";
            DataTable dt = SQLUtility.GetDataTable(sql);
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
                        left JOIN Directions d 
                        ON r.RecipeID = d.RecipeID 
                        left JOIN CourseMealRecipe cmr 
                        ON r.RecipeID = cmr.RecipeID 
                        left JOIN CookbookRecipe cbr 
                        ON r.RecipeID = cbr.RecipeID
                        where
                        (r.recipeStatus = 'published' or DATEDIFF(day, r.ArchivedDate, GETDATE())<30)
                        ";
            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeID = 0;
            if (dt.Rows.Count > 0)
            {
                recipeID = (int)dt.Rows[0]["recipeID"];
            }
            Assume.That(recipeID > 0, "no recipes are currently published or archived less than 30 days ago, cannot perform test");
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

        [Test]
        [TestCase("Users", "UsersID", "UsersGet")]
        [TestCase("Cuisine", "CuisineID", "CuisineGet")]
        [TestCase("Ingredient", "IngredientID", "IngredientGet")]
        [TestCase("Measurement", "MeasurementID", "MeasurementGet")]
        [TestCase("Course", "CourseID", "CourseGet")]
        public void LoadEntity(string entityName, string idColumn, string getProcedure)
        {
            string sql = $"SELECT TOP 1 {idColumn} FROM {entityName}";
            int entityID = SQLUtility.GetFirstColumnFirstRowValue(sql);
            Assume.That(entityID > 0, $"No {entityName} found in database, can't do test");
            TestContext.WriteLine($"Existing {entityName} with ID= " + entityID);

            DataTable dt = SQLUtility.GetDataTable($"EXEC {getProcedure} @{idColumn}={entityID}");
            ClassicAssert.IsTrue(dt.Rows.Count == 1, $"{entityName} with ID={entityID} could not be loaded.");
        }

        [Test]

        [TestCase("Users", "UsersID", "UsersDelete")]
        [TestCase("Cuisine", "CuisineID", "CuisineDelete")]
        [TestCase("Ingredient", "IngredientID", "IngredientDelete")]
        [TestCase("Measurement", "MeasurementID", "MeasurementDelete")]
        [TestCase("Course", "CourseID", "CourseDelete")]
        public void DeleteEntity(string entityName, string idColumn, string deleteProcedure)
        {
            string sql = $"SELECT TOP 1 {idColumn} FROM {entityName}";
            int entityID = SQLUtility.GetFirstColumnFirstRowValue(sql);
            Assume.That(entityID > 0, $"No {entityName} found in database, can't do test");
            TestContext.WriteLine($"Deleting {entityName} with ID= " + entityID);

            SQLUtility.ExecuteSQL($"EXEC {deleteProcedure} @{idColumn}={entityID}");

            int checkID = SQLUtility.GetFirstColumnFirstRowValue(sql);
            ClassicAssert.IsTrue(checkID != entityID, $"{entityName} with ID={entityID} still exists in database.");
        }

        [Test]
        [TestCase("Cuisine", "CuisineID", "CuisineName", "CuisineUpdate")]
        [TestCase("Ingredient", "IngredientID", "IngredientName", "IngredientUpdate")]
        [TestCase("Measurement", "MeasurementID", "MeasurementName", "MeasurementUpdate")]
        public void UpdateTable(string entityName, string idColumn, string nameColumn, string updateProcedure)
        {
            string sql = $"SELECT TOP 1 {idColumn} FROM {entityName}";
            int entityID = SQLUtility.GetFirstColumnFirstRowValue(sql);
            Assume.That(entityID > 0, $"No {entityName} found in database, can't do test");
            TestContext.WriteLine($"Updating {entityName} with ID= " + entityID);

            DataTable dt = SQLUtility.GetDataTable($"EXEC {entityName}Get @{idColumn}={entityID}");
            dt.Rows[0][nameColumn] = dt.Rows[0][nameColumn].ToString() + " Updated";
            SQLUtility.ExecuteSQL($"EXEC {updateProcedure} @{idColumn}={entityID}, @{nameColumn}='{dt.Rows[0][nameColumn]}'");

            DataTable updatedDt = SQLUtility.GetDataTable($"EXEC {entityName}Get @{idColumn}={entityID}");
            ClassicAssert.IsTrue(updatedDt.Rows[0][nameColumn].ToString().EndsWith(" Updated"), "Update did not persist in database.");
        }

        [Test]
        [TestCase("Users", "UsersID", "UsersName", "UsersFirstName", "UsersLastName", "UsersUpdate")]
        public void UpdateUsers(
                string entityName,
                string idColumn,
                string nameColumn,
                string additionalColumn1,
                string additionalColumn2,
                string updateProcedure)
        {
            // Fetch an existing entity's ID
            string sql = $"SELECT TOP 1 {idColumn} FROM {entityName}";
            int entityID = SQLUtility.GetFirstColumnFirstRowValue(sql);
            Assume.That(entityID > 0, $"No {entityName} found in database, can't do test");
            TestContext.WriteLine($"Updating {entityName} with ID= {entityID}");

            // Retrieve the current entity data
            DataTable dt = SQLUtility.GetDataTable($"EXEC {entityName}Get @{idColumn}={entityID}");

            // Modify necessary columns
            dt.Rows[0][nameColumn] = dt.Rows[0][nameColumn].ToString() + " Updated";

            string sqlCommand = $"EXEC {updateProcedure} @{idColumn}={entityID}, @{nameColumn}='{dt.Rows[0][nameColumn]}'";

            // Handle extra parameters if applicable
            if (!string.IsNullOrEmpty(additionalColumn1))
            {
                dt.Rows[0][additionalColumn1] = dt.Rows[0][additionalColumn1].ToString() + " Updated";
                sqlCommand += $", @{additionalColumn1}='{dt.Rows[0][additionalColumn1]}'";
            }
            if (!string.IsNullOrEmpty(additionalColumn2))
            {
                if (dt.Rows[0][additionalColumn2] is int) // For integer fields like CourseSequence
                {
                    dt.Rows[0][additionalColumn2] = (int)dt.Rows[0][additionalColumn2] + 1;
                    sqlCommand += $", @{additionalColumn2}={dt.Rows[0][additionalColumn2]}";
                }
                else // For string fields
                {
                    dt.Rows[0][additionalColumn2] = dt.Rows[0][additionalColumn2].ToString() + " Updated";
                    sqlCommand += $", @{additionalColumn2}='{dt.Rows[0][additionalColumn2]}'";
                }
            }

            // Execute the update
            SQLUtility.ExecuteSQL(sqlCommand);

            // Retrieve updated data to verify persistence
            DataTable updatedDt = SQLUtility.GetDataTable($"EXEC {entityName}Get @{idColumn}={entityID}");
            ClassicAssert.IsTrue(updatedDt.Rows[0][nameColumn].ToString().EndsWith(" Updated"), "Update did not persist in database.");
        }

        [Test]
        public void UpdateCourse()
        {
            // Fetch an existing CourseID
            string sql = "SELECT TOP 1 CourseID FROM Course";
            int courseID = SQLUtility.GetFirstColumnFirstRowValue(sql);
            Assume.That(courseID > 0, "No Course found in database, can't do test");
            TestContext.WriteLine($"Updating Course with ID= {courseID}");

            // Retrieve current course data
            DataTable dt = SQLUtility.GetDataTable($"EXEC CourseGet @CourseID={courseID}");

            // Modify CourseName and CourseSequence
            dt.Rows[0]["CourseName"] = dt.Rows[0]["CourseName"].ToString() + " Updated";
            dt.Rows[0]["CourseSequence"] = (int)dt.Rows[0]["CourseSequence"] + 1; // Increment sequence number

            // Execute CourseUpdate procedure with modified values
            string sqlCommand = $"EXEC CourseUpdate @CourseID={courseID}, @CourseName='{dt.Rows[0]["CourseName"]}', @CourseSequence={dt.Rows[0]["CourseSequence"]}";
            SQLUtility.ExecuteSQL(sqlCommand);

            // Retrieve updated data to verify persistence
            DataTable updatedDt = SQLUtility.GetDataTable($"EXEC CourseGet @CourseID={courseID}");
            ClassicAssert.IsTrue(updatedDt.Rows[0]["CourseName"].ToString().EndsWith(" Updated"), "CourseName update did not persist.");
            ClassicAssert.IsTrue((int)updatedDt.Rows[0]["CourseSequence"] == (int)dt.Rows[0]["CourseSequence"], "CourseSequence update did not persist.");
        }

        [Test]
        [TestCase("Test Cookbook", "2025-02-01", 20)]
        public void InsertNewCookbook(string CookbookName, string createdDateStr, decimal price)
        {
            // Convert string date to DateTime
            DateTime CreatedDate = DateTime.Parse(createdDateStr);

            // Create a new DataTable to hold the cookbook data
            DataTable dt = Cookbook.Load(0);
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);

            int UsersID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 usersid from users");
            TestContext.WriteLine("userid is" + UsersID);
            Assume.That(UsersID > 0, "no Users in database, cant do test");

            dt.Columns["CookbookID"].ReadOnly = false;
            r["CookbookName"] = CookbookName;
            r["DateCreated"] = CreatedDate;
            r["UsersID"] = UsersID;
            r["price"] = price;
            
            // Save the new cookbook to the database
            Cookbook.Save(dt);

            // Retrieve the new CookbookID based on the CookbookName
            string query = $"SELECT CookbookID FROM Cookbook WHERE CookbookName LIKE '%{CookbookName}%'";
            int newID = SQLUtility.GetFirstColumnFirstRowValue(query);

            // Assert that the new CookbookID is valid
            ClassicAssert.IsTrue(newID > 0, "Cookbook with CookbookName = " + CookbookName + " is not found in the database.");
            TestContext.WriteLine("Cookbook with " + CookbookName + " is found in the database with primary key value = " + newID);
        }

        [Test]
        [TestCase(1, "Updated Cookbook Name", "2025-01-01")]
        public void UpdateExistingCookbook(int CookbookID, string NewCookbookName, string newCreatedDateStr)
        {
            DateTime NewCreatedDate = DateTime.Parse(newCreatedDateStr);

            // Load the cookbook data into a DataTable
            DataTable dt = Cookbook.Load(CookbookID);
            Assume.That(dt.Rows.Count == 1, "No cookbook found for the given CookbookID.");

            // Update the cookbook details
            dt.Rows[0]["CookbookName"] = NewCookbookName;
            dt.Rows[0]["DateCreated"] = NewCreatedDate;
            dt.Columns["CookbookID"].ReadOnly = false;

            // Save the updated cookbook data
            Cookbook.Save(dt);

            // Retrieve the updated cookbook details from the database
            string query = $"SELECT CookbookName, DateCreated FROM Cookbook WHERE CookbookID = {CookbookID}";
            DataTable updatedDt = SQLUtility.GetDataTable(query);

            string updatedName = updatedDt.Rows[0]["CookbookName"].ToString();
            DateTime updatedDate = (DateTime)updatedDt.Rows[0]["DateCreated"];

            // Assert that the updated cookbook name and date match
            ClassicAssert.IsTrue(updatedName == NewCookbookName, "Cookbook name was not updated.");
            ClassicAssert.IsTrue(updatedDate == NewCreatedDate, "Cookbook creation date was not updated.");
        }

        [Test]
        public void DeleteCookbook()
        {
            int CookbookID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 CookbookID from cookbook");
            TestContext.WriteLine("CookbookID is" + CookbookID);

            // Assume that the cookbook exists
            DataTable dt = Cookbook.Load(CookbookID);
            Assume.That(dt.Rows.Count == 1, "No cookbook found for the given CookbookID.");

            // Delete the cookbook
            Cookbook.Delete(dt);

            // Retrieve the cookbook data after deletion
            DataTable dtAfterDelete = Cookbook.Load(CookbookID);

            // Assert that the cookbook has been deleted
            ClassicAssert.IsTrue(dtAfterDelete.Rows.Count == 0, "Cookbook with CookbookID = " + CookbookID + " still exists in the database.");
            TestContext.WriteLine("Cookbook with CookbookID = " + CookbookID + " is successfully deleted.");
        }
                [Test]
        public void SaveCookbookRecipe()
        {

            int CookbookID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 CookbookID from cookbook");
            TestContext.WriteLine("CookbookID is" + CookbookID);

            int RecipeID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 RecipeID from Recipe");
            TestContext.WriteLine("RecipeID is" + RecipeID);

            int CookBookSequenceNumber = SQLUtility.GetFirstColumnFirstRowValue($"select top 1 CookBookSequenceNumber from CookbookRecipe where cookbookID= {CookbookID} ORDER by CookBookSequenceNumber desc");



            // Load the cookbook recipe data
            DataTable dtCookbookRecipe = CookbookRecipe.LoadByCookbookID(CookbookID);
            DataRow newRow = dtCookbookRecipe.Rows.Add();
            newRow["CookbookID"] = CookbookID;
            newRow["RecipeID"] = RecipeID;
            newRow["CookBookSequenceNumber"] = CookBookSequenceNumber+1;

            // Save the cookbook recipe
            CookbookRecipe.SaveTable(dtCookbookRecipe, CookbookID);

            // Retrieve the cookbook recipe to check if it was saved
            string query = $"SELECT RecipeID FROM CookbookRecipe WHERE CookbookID = {CookbookID} AND RecipeID = {RecipeID}";
            DataTable savedRecipe = SQLUtility.GetDataTable(query);

            // Assert that the recipe is saved
            ClassicAssert.IsTrue(savedRecipe.Rows.Count > 0, "CookbookRecipe with CookbookID = " + CookbookID + " and RecipeID = " + RecipeID + " is not found.");
            TestContext.WriteLine("CookbookRecipe with CookbookID = " + CookbookID + " and RecipeID = " + RecipeID + " is saved.");
        }
        
        [Test]

        public void DeleteCookbookRecipe()
        {
            // Get a CookbookID from the cookbook table
            int CookbookID = SQLUtility.GetFirstColumnFirstRowValue("select top 1 CookbookID from cookbook");
            TestContext.WriteLine("CookbookID is" + CookbookID);
            // Retrieve the CookbookRecipeID for this CookbookID
            string sql = $"select top 1 CookbookRecipeID from CookbookRecipe where cookbookID = {CookbookID}";
            DataTable dt = SQLUtility.GetDataTable(sql);


            // If there is no CookbookRecipeID, fail the test
            Assume.That(dt.Rows.Count > 0, "No recipes found in Cookbook. Cannot perform the test.");
            int CookbookRecipeID = (int)dt.Rows[0]["CookbookRecipeID"];
            TestContext.WriteLine("Existing CookbookRecipe with CookbookRecipeID = " + CookbookRecipeID);


            // Delete the cookbook recipe
            CookbookRecipe.Delete(CookbookRecipeID);

            // Retrieve the cookbook recipe data to confirm deletion
            DataTable updatedDt = CookbookRecipe.LoadByCookbookID(CookbookID);

            // Assert that the recipe is deleted
            ClassicAssert.IsTrue(updatedDt.Rows.Cast<DataRow>().All(r => (int)r["CookbookRecipeID"] != CookbookRecipeID),
                "Record with CookbookRecipeID " + CookbookRecipeID + " still exists in the DB.");
            TestContext.WriteLine("CookbookRecipe with CookbookRecipeID = " + CookbookRecipeID + " is successfully deleted.");
        }

    }
}


