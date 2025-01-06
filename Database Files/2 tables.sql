-- SM Excellent! See comments, no need to resubmit.
use HeartyHealthDB
GO

DROP table if EXISTS CookbookRecipe
DROP table if EXISTS Cookbook
drop table if EXISTS Coursemealrecipe
drop table if EXISTS CourseMeal
DROP TABLE if EXISTS course
drop table if EXISTS Meal
drop table if EXISTS Directions
drop table if exists RecipeIngredient
drop table if EXISTS ingredient
drop table if EXISTS recipe
drop TABLE if EXISTS Cuisine
drop table if EXISTS Measurement
drop table if exists users
go

create table dbo.users(
    UsersID int not null Identity PRIMARY KEY, 
    usersFirstName varchar(35) CONSTRAINT ck_Users_First_name_is_not_blank check(UsersFirstName <> ''),
    UsersLastName varchar(35) CONSTRAINT ck_users_Last_name_is_not_blank check(UsersLastName <> ''),
    UsersName varchar(35) 
            CONSTRAINT ck_Users_users_name_is_not_blank check(UsersName <> '') 
            constraint USERs_NAME_is_unique UNIQUE
)
go

CREATE table dbo.ingredient(
    ingredientID int not null Identity PRIMARY KEY, 
    ingredientName varchar(35)
            CONSTRAINT ck_ingredient_name_is_not_blank check(ingredientname <> '') 
-- SM Tip: No need to include column name when doing unique constraint on the column.
            constraint ingredient_name_is_unique UNIQUE(ingredientname),
    Picture as concat('ingredient_', replace(ingredientName, ' ', '_'), '.jpg')
)
go

create table dbo.Cuisine(
    CuisineID int not null Identity PRIMARY KEY, 
    CuisineName varchar(35) 
            CONSTRAINT ck_Cuisne_Cuisne_name_is_not_blank check(CuisineName <> '') 
            constraint u_Cuisne_Cuisne_name_is_unique UNIQUE
)
go 

CREATE table dbo.recipe(
    RecipeID int not null Identity PRIMARY KEY,
    CuisineID int not null constraint f_Cuisine_recipe REFERENCES Cuisine(CuisineID),
    UsersID int not null constraint f_Users_recipe REFERENCES Users(UsersID),
    RecipeName varchar(50)
            CONSTRAINT ck_Recipe_Recipe_name_is_not_blank check(RecipeName <> '') 
            constraint u_Recipe_Recipe_name_is_unique UNIQUE,
    Calories int not null constraint ck_calories_not_less_than_0 CHECK(calories>0), 
-- SM Tip: DraftedDate should be defaulted to current date
    DraftedDate date not null  DEFAULT GETDATE() constraint ck_recipe_Drafted_date_is_not_in_future CHECK(drafteddate <= CURRENT_TIMESTAMP) , 
    PublishedDate DATETIME null DEFAULT GETDATE()  constraint ck_recipe__Published_Dateis_not_in_future CHECK(PublishedDate <= CURRENT_TIMESTAMP),
    ArchivedDate DATETIME null DEFAULT GETDATE()  constraint ck_recipe_Archived_Date_is_not_in_future CHECK(ArchivedDate <= CURRENT_TIMESTAMP),
    Picture as concat('recipe_', replace(RecipeName, ' ', '_'), '.jpg'),
-- SM Column name should be RecipeStatus as Status is a reserved word.
    RecipeStatus as case
        when PublishedDate is null and ArchivedDate is null then 'Drafted' 
        when PublishedDate is not null and ArchivedDate is null then 'Published'
        else 'Archived' 
        end,
-- SM Tip: You can combine two of the following constraints with between.
    CONSTRAINT ck_archive_date_is_after_publshed_date check(PublishedDate <ArchivedDate),
    constraint ck_published_date_is_after_drafted_date CHECK(DraftedDate<PublishedDate), 
    constraint ck_drafted_date_is_before_published_date CHECK(DraftedDate<ArchivedDate)
)
go 


CREATE table dbo.Measurement(
    MeasurementID int not null Identity PRIMARY key,
    MeasurementName varchar(35) not null
        CONSTRAINT ck__Measurement_MeasurementName_is_not_blank check(MeasurementName <> '') 
        Constraint u_Measurement_MeasurementName_is_unique UNIQUE
)
go 

CREATE TABLE dbo.RecipeIngredient( 
    RecipeIngredientID int not null Identity PRIMARY KEY, 
    RecipeID int not null constraint f_Recipe_RecipeIngredient REFERENCES Recipe(RecipeID), 
    IngredientID int not null CONSTRAINT f_Ingredient_RecipeIngredient REFERENCES Ingredient(IngredientID),
    MeasurementID int null CONSTRAINT f_Measurement_Recipeingredient REFERENCES Measurement(MeasurementID),
    Amount decimal(5,2) not null constraint ck_Amount_not_less_than_0 CHECK(Amount>=0), 
    SequenceNumber int not null constraint ck_SequenceNumber_not_less_than_0 CHECK(SequenceNumber>0),
    CONSTRAINT u_recipeID_ingredientID UNIQUE(recipeID, ingredientID),
    CONSTRAINT u_sequence#_RecipeID UNIQUE(SequenceNumber, recipeID)
)
go 

CREATE table dbo.Directions(
    directionsID int not null Identity Primary Key, 
    RecipeID int not null CONSTRAINT f_recipe_Directions REFERENCES Recipe(recipeID),
    Direction varchar(1000) not null CONSTRAINT ck_Direction_Direction_is_not_blank check(Direction <> ''), 
    StepNumber int not null constraint ck_Driections_Step_number_is_not_less_than_0 CHECK (stepNumber> 0),
    CONSTRAINT u_Step#_RecipeID UNIQUE(stepNumber, recipeID)
)
go 

create table dbo.Meal(
    MealID int not null Identity PRIMARY KEY, 
    UsersID int not null constraint f_users_Meal REFERENCES Users(UsersID),
    MealName varchar(50) 
            CONSTRAINT ck_Meal_Meal_Name_is_not_blank check(MealName <> '') 
            constraint u_Meal_Meal_Name_is_unique UNIQUE,
    active bit not null Default 1,
-- SM Tip: Default to current date.
    DateCreated date not null constraint ck_meal_DateCreated_is_not_in_future CHECK(DateCreated <= CURRENT_TIMESTAMP), 
    Picture as concat('Meal_', replace(MealName, ' ', '_'), '.jpg')
)

go

create table dbo.course(
    CourseID int not null IDENTITY PRIMARY KEY,
    CourseName VARCHAR(50) not null 
            CONSTRAINT ck_Course_Course_Name_is_not_blank check(CourseName <> '') 
            constraint u_Course_Course_Name_is_unique UNIQUE,
    courseSequence int not null 
        constraint ck_Course_Sequence_is_not_les_than_0 CHECK(courseSequence > 0)
        CONSTRAINT u_Course_sequence_is_unique UNIQUE
)

GO

create table dbo.CourseMeal(
    CourseMealID int not null Identity primary KEY, 
-- SM Rename FK constraint name. It should be f_Parant_child.
    CourseID int not null CONSTRAINT f__meal_course REFERENCES course(courseID),
-- SM Rename FK constraint name. It should be f_Parant_child.
    MealID int not null CONSTRAINT f_course_meal REFERENCES meal(mealID),
    CONSTRAINT u_mealID_courseID UNIQUE(mealID, courseID)
)

go

CREATE table dbo.CourseMealRecipe(
    CourseMealRecipeID int not null Identity PRIMARY key, 
    CourseMealID int not null constraint f_Coursemeal_CourseMealRecipe REFERENCES CourseMeal(CourseMealID),
    RecipeID int not null CONSTRAINT f_recipe_CourseMealRecipe REFERENCES recipe(recipeID),
    MaidDish bit not null, 
    CONSTRAINT u_courseID_MealID_RecipeID UNIQUE(CourseMealID, recipeID)
)
go 

CREATE table dbo.CookBook(
    CookbookID int not null Identity PRIMARY key, 
    UsersID int not null constraint f_users_cookbook REFERENCES Users(UsersID),
    CookbookName varchar(100) not null 
            CONSTRAINT ck_Cookbook_Cookbook_Name_is_not_blank check(CookbookName <> '') 
            constraint u_Cookbook_Cookbook_Name_is_unique UNIQUE,
    Price decimal not null CONSTRAINT ck_Cookbook_price_is_not_less_than_0 CHECK (price > 0),
-- SM Tip: Default to current date.
    DateCreated date not null constraint ck_cookbook_DateCreated_is_not_in_future CHECK(DateCreated <= CURRENT_TIMESTAMP),
    Active bit not null DEFAULT 1, 
    Picture as concat('CookBook_', replace(CookbookName, ' ', '_'), '.jpg')
)

GO

CREATE table dbo.CookbookRecipe(
    CookbookRecipeID int not null Identity PRIMARY key, 
    cookbookID int not null CONSTRAINT f_cookbook_CookbookRecipe REFERENCES cookbook(cookbookID),
    RecipeID int not null CONSTRAINT f_recipe_CookbookRecipe REFERENCES recipe(recipeID),
    CookBookSequenceNumber int not null constraint ck_CookbookRecipe_SequenceNumber_not_less_than_0 check(CookBookSequenceNumber>0 ), 
    CONSTRAINT u_cookbookID_recipeID UNIQUE(cookbookID, recipeID), 
    CONSTRAINT u_cookbookID_sequencenumber UNIQUE(cookbookID, CookBookSequenceNumber)

)
go 


