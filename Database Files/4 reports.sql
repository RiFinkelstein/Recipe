-- SM Excellent! 100% See comments, no need to resubmit.
/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/
select * from recipe
/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
select Item_name= 'Recipes', count= count(r.recipeID) from recipe R 
union select 'Meals', count(m.mealID) from Meal m 
union select 'Cookbook', COUNT(CB.cookbookID) from CookBook cb



/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/
;with x as( 
    select numberofingredients= COUNT(Ri.ingredientID), r.recipeID
    from recipe R 
    join RecipeIngredient RI 
    on Ri.recipeID = r.recipeID
    group by r.recipeID
) 
SELECT recipename= case
            when r.status= 'archived' then '<span style="color:gray">' + r.recipename + '</span>' 
            else '<span style="color:black">' + r.recipename + '</span>' end,
            r.status, 
            PublishedDate= convert(varchar(10), r.PublishedDate, 101),
            ArchivedDate= isnull(convert(varchar(10), r.ArchivedDate, 101), ' '), 
            u.UserName, 
            r.calories, 
            x.numberofingredients, 
            r.Picure
from X 
JOIN recipe R 
ON R.RecipeID = X.RecipeID
join Users u 
on u.UsersID= r.usersID
where r.STATUS in ('Published', 'archived')
order by r.STATUS desc


/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
SELECT r.recipename, r.Calories, numberofingredients= count(distinct RI.ingredientID), numberofsteps= count(distinct D.directionsID), r.Picure
from recipe R
join RecipeIngredient RI 
on RI.recipeID = r.RecipeID
join Directions d
on  d.recipeID = r.recipeID
where r.recipename= 'Apple yogurt smoothie'
group by r.recipename, r.calories, r.Picure

SELECT Listofingredients= concat(RI.Amount, ' ', m.MeasurementName, ' ', I.ingredientName)
from Recipe R
join RecipeIngredient RI 
on r.recipeID = ri.recipeID
join ingredient i 
on i.ingredientID = RI.ingredientID
LEFT join Measurement m 
on m.MeasurementID = ri.MeasurementID
where r.recipename= 'Apple yogurt smoothie'
order by ri.SequenceNumber

SELECT d.Direction, d.StepNumber 
from Directions D 
join recipe r 
on d.RecipeID= r.RecipeID
where r.recipename= 'Apple yogurt smoothie'
order by d.StepNumber


/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
SELECT  m.MealName, u.UserName, NumberofCourses= count(distinct CM.courseID), Numberofrecipes= count(distinct r.recipeID), Calories= Sum(r.Calories) 
from meal m 
join Users u 
on u.UsersID = m.UsersID
join CourseMeal CM 
on CM.MealID = m.MealID
join CourseMealRecipe CMR 
on CM.CourseMealID= CMR.CourseMealID
join recipe R 
on r.RecipeID = CMR.RecipeID
WHERE m.active = 1 
group by m.MealName, u.UserName
order by m.MealName


/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
SELECT m.MealName, u.UserName, m.DateCreated 
from meal M 
join users u 
on u.UsersID= m.UsersID
where m.MealName= 'BreakFast Bash'

SELECT ListofRecipes= case 
    when c.CourseName= 'Main Course' and cmr.MaidDish =1 then '<b>Main: Main Dish - '+ r.RecipeName+ '</b>'
    when c.CourseName= 'Main Course' and cmr.MaidDish =0 then 'Main: Side Dish - '+ r.RecipeName
    else CONCAT(c.CourseName, ': ', r.RecipeName)
    end
from meal M 
join CourseMeal CM 
on CM.MealID = M.MealID
join CourseMealRecipe CMR
on Cm.CourseMealID = CMR.CourseMealID
join recipe R
on r.RecipeID = CMR.RecipeID
join course C
on cm.CourseID= c.CourseID
where m.MealName= 'BreakFast Bash'



/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
SELECT cb.CookbookName, u.UsersFirstName, u.UsersLastName, numberofrecipes=COUNT(CBR.recipeID)
from CookBook CB 
join Users u
on u.UsersID= cb.UsersID
join CookbookRecipe CBR 
on CBR.cookbookID= cb.CookbookID
where CB.Active = 1
GROUP BY cb.cookbookname, u.UsersFirstName, u.UsersLastName
order by cb.CookbookName


/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
SELECT cb.CookbookName, u.UserName, cb.DateCreated, cb.Price, numberofrecipes= COUNT(CBR.recipeID)
from CookBook CB 
join Users u 
on u.UsersID = cb.UsersID
join CookbookRecipe CBR 
on CBR.cookbookID = CB.cookbookID
where cb.cookbookname= 'Treats for two'
group by cb.CookbookName, u.UserName, cb.DateCreated, cb.Price

SELECT r.RecipeName, c.CuisineName, numberofstepss= COUNT(distinct d.directionsID) , numberofingrdeients= COUNT(distinct ri.IngredientID)
from CookBook CB 
join CookbookRecipe CBR 
on CBR.cookbookID = CB.cookbookID
join recipe r 
on r.RecipeID = CBR.RecipeID
join Cuisine c 
on c.CuisineID = r.CuisineID
join Directions d 
on d.RecipeID = r.RecipeID
join RecipeIngredient RI 
on RI.RecipeID = r.RecipeID
where cb.cookbookname= 'Treats for two'
group by r.RecipeName, c.CuisineName, CBR.CookBookSequenceNumber
order by CBR.CookBookSequenceNumber



/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
SELECT ReversedName=trim(concat(UPPER(SUBSTRING(REVERSE(r.RecipeName), 1, 1)), LOWER(SUBSTRING(REVERSE(r.RecipeName), 2, lEN(R.RecipeName))))), UPDATEpicture= replace(trim(concat( 'Recipe ', UPPER(SUBSTRING(REVERSE(r.RecipeName), 1, 1)), LOWER(SUBSTRING(REVERSE(r.RecipeName), 2, 20)),'.jpg')), ' ', '_')
from recipe R 
join CookbookRecipe CBR 
on r.RecipeID = CBR.RecipeID

;with x as(
    SELECT RecipeID= d.recipeID, LastStepNumber= max(d.stepNumber)
    from Directions d 
    group by d.RecipeID
)
SELECT D.direction 
from recipe r 
inner join x 
on r.RecipeID = x.RecipeID
INNER JOIN Directions d 
on d.RecipeID= r.RecipeID and d.StepNumber= x.LastStepNumber



/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
SELECT RecipeCount= count(r.recipename), u.UserName 
from users u 
left join recipe r 
on u.UsersID = r.UsersID
group by u.UserName

SELECT RecipeCount= count(r.recipename), AvergaeTimefromDraftedtopublished= ISNULL(CONVERT(vARCHAR, avg(datediff(day, r.DraftedDate, r.publisheddate))), 'N/A'), u.UserName 
from users u 
left join recipe r 
on u.UsersID = r.UsersID
group by u.UserName

SELECT u.username, TotalMeals=count(m.mealID), TotalActiveMeals= sum(case when m.active= 1 then 1 else 0 end),  TotalinactiveActiveMeals = sum(case when m.active= 0 then 1 else 0 end)
from Users u 
left join meal m
on m.usersID = u.UsersID
GROUP by u.UserName

SELECT u.username, TotalCookbooks= count(cb.CookbookID), TotalActiveMeals= sum(case when cb.active= 1 then 1 else 0 end),  TotalinactiveActiveMeals = sum(case when cb.active= 0 then 1 else 0 end)
from Users u 
left join CookBook cb
on cb.usersID = u.UsersID
GROUP by u.UserName

select r.RecipeName, Daystooktobearchived= DATEDIFF(day, r.DraftedDate, r.ArchivedDate) 
from recipe r 
where r.status = 'archived' and r.PublishedDate is null

/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
    
    OPTIONAL CHALLENGE QUESTION
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
*/
select Item_name= 'Recipes', count= count(r.recipeID)
    from recipe R
    join Users u 
    on u.UsersID = r.UsersID
    WHERE u.UserName= 'JGreen' 
union select 'Meals', count(distinct m.mealID)
    from Meal m 
    join Users u 
    on u.UsersID = m.usersID
    WHERE u.UserName= 'JGreen' 
union select 'Cookbook', COUNT(distinct CB.cookbookID)
    from CookBook cb
    join Users u 
    on u.UsersID = cb.usersID
    WHERE u.UserName= 'JGreen' 

select r.DraftedDate, r.PublishedDate, r.ArchivedDate, r.status, r.recipename, HoursbetweenStatus= 
    case 
    when r.status= 'Archived' and  r.PublishedDate is not null then datediff(hour, r.PublishedDate, r.ArchivedDate)
    when r.status= 'Archived' and  r.PublishedDate is null then datediff(hour, r.DraftedDate, r.ArchivedDate)
    when r.status= 'Published' then datediff(hour, r.DraftedDate, r.PublishedDate)
    else 0 
    end
from recipe R 
join Users U 
on u.UsersID = r.UsersID
WHERE u.UserName = 'JGreen' and  r.Status != 'drafted'


;with x as( 
    SELECT c.CuisineID, NumRecipes = COUNT(*), u.UserName
    FROM RECIPE R
    JOIN Cuisine c 
    on r.CuisineID = c.CuisineID
    join Users u 
    on u.UsersID = r.UsersID
	where u.UserName = 'CCollins'
	group by c.CuisineID, u.UserName
)
select u.UserName, Recipecount= isnull(x.NumRecipes,0), c.CuisineName
from Cuisine c
join Users u 
on u.UserName = 'CCollins'
left join x
on x.CuisineID = c.CuisineID
order by Recipecount desc, c.CuisineName
