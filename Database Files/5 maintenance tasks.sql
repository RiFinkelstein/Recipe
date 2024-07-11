-- SM Excellent! See comments, no need to resubmit.
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.
use HeartyHealthDB
--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.
delete CMR
--select * 
from CourseMealRecipe CMR 
join Recipe R
on r.RecipeID = CMR.RecipeID
join Users U 
on u.UsersID = r.UsersID
where u.username = 'JGreen'

delete CMR
--select * 
from CourseMealRecipe CMR 
join CourseMeal CM
on cmr.CourseMealID = CM.CourseMealID
join Meal M 
on M.MealID = cm.MealID
join Users U 
on u.UsersID = m.UsersID
where u.username = 'JGreen'

DELETE CM
--select * 
from CourseMeal CM 
join Meal m 
on m.MealID= cm.MealID 
join Users u 
on u.UsersID= m.UsersID
where u.username = 'JGreen'

Delete CR
from CookbookRecipe CR
join Recipe R
on r.RecipeID = Cr.RecipeID
join Users U 
on u.UsersID = r.UsersID
where u.username = 'JGreen'

DELETE CR 
from CookbookRecipe CR 
join CookBook C
on c.CookbookID = CR.cookbookID
join Users u 
on u.UsersID =c.UsersID
where u.username = 'JGreen'

delete RI
--select * 
from RecipeIngredient RI 
join recipe R
on R.RecipeID = RI.RecipeID
join Users u
on u.UsersID = r.UsersID
where u.username = 'JGreen'

delete D
--select * 
from directions D
join recipe R
on R.RecipeID = D.RecipeID
join Users u
on u.UsersID = r.UsersID
where u.username = 'JGreen'

delete R 
from recipe R 
join users u
on r.UsersID = u.UsersID
where u.username = 'JGreen'

delete m 
from Meal m 
join users u
on m.UsersID = u.UsersID
where u.username = 'JGreen'

delete C 
from CookBook C 
join users u
on c.UsersID = u.UsersID
where u.username = 'JGreen'

delete U 
from users u
where u.username = 'JGreen'


--2) Sometimes we want to clone a recipe as a starting point and then edit it. For example we have a complex recipe (steps and ingredients) and want to make a modified version. Write the SQL that clones a specific recipe, add " - clone" to its name.
insert Recipe(UsersID, CuisineID, RecipeName, calories, DraftedDate, PublishedDate, ArchivedDate)
select r.UsersID, r.CuisineID, CONCAT(r.RecipeName, ' --clone'), r.Calories, r.DraftedDate, r.PublishedDate, r.ArchivedDate
from recipe R 
WHERE r.RecipeName = 'Chocolate Chip Cookies' 

Insert RecipeIngredient(RecipeID, IngredientID, MeasurementID, Amount, SequenceNumber)
SELECT (select r.RecipeID from recipe r where r.RecipeName = 'Chocolate Chip Cookies --clone'), ri.IngredientID, ri.MeasurementID, ri.Amount, ri.SequenceNumber
from RecipeIngredient RI 
join recipe r 
on r.RecipeID = ri.RecipeID
WHERE r.RecipeName = 'Chocolate Chip Cookies' 

insert Directions(r.recipeID, Direction, StepNumber)
SELECT (select r.RecipeID from recipe r where r.RecipeName = 'Chocolate Chip Cookies --clone'), D.direction, d.stepNumber
from Directions D
join recipe R 
on r.RecipeID = d.RecipeID
where r.RecipeName= 'Chocolate Chip Cookies' 

/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/
insert CookBook(UsersID, CookbookName, price, DateCreated, Active)
select  u.UsersID, CONCAT('Recipes by ', u.usersFirstName, ' ', u.UsersLastName), count(r.recipeID)*1.33, getdate(), 1
from Users U 
join Recipe R 
on R.UsersID = u.UsersID 
WHERE u.UserName = 'JGreen'
group by u.UsersID, u.UsersFirstName, u.UsersLastName

INSERT CookbookRecipe(cookbookID, RecipeID, CookBookSequenceNumber)
SELECT cb.CookbookID, r.RecipeID, ROW_NUMBER() over(order by r.recipename)
from CookBook CB 
join Users u
on CB.UsersID= u.usersID 
join recipe R 
on r.UsersID = u.UsersID
where CookbookName = 'Recipes by John Green'


/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
update R
set r.Calories=
	case 
	when M.MeasurementName = 'Teaspoon' then r.Calories+2
	when m.MeasurementName = 'Cup' then r.Calories+10
	else r.Calories
	end
--SELECT R.RecipeName, I.ingredientName, RI.Amount, M.MeasurementName,  R.Calories
from recipe R 
join RecipeIngredient RI 
on RI.RecipeID = R.RecipeID 
join ingredient I 
on I.ingredientID = RI.IngredientID
join Measurement M 
on m.MeasurementID = RI.MeasurementID
where I.ingredientName = 'sugar'

/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
-- SM Tip: Add data that this should return something.
;with x as( 
	select Averafetimeindrafts= avg(DATEDIFF(HOUR, r.DraftedDate, r.PublishedDate))
	from recipe R 
)
SELECT u.UsersFirstName, u.UsersLastName, EmailAddress= concat(SUBSTRING(u.usersFirstName,1,1), u.UsersLastName,'@heartyhearth.com')
		,Alert= concat('Your recipe ', r.recipename, ' is sitting in draft for ', DATEDIFF(HOUR, r.DraftedDate, r.PublishedDate), ' hours.
		That is ', DATEDIFF(HOUR, r.DraftedDate, r.PublishedDate)-x.Averafetimeindrafts, ' hours more than the average ', x.Averafetimeindrafts, ' hours all other recipes took to be published.')
from users U
join recipe R 
on r.UsersID = u.UsersID
cross join x
-- SM Instead of doing calculation. Use where datediff() > avg.
where DATEDIFF(HOUR, r.DraftedDate, r.PublishedDate)-x.Averafetimeindrafts > 0 and 
r.status= 'Drafted'

/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and recieve a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
-- SM Tip: No need to cast() the GUID.
select EmailBody= concat('Order cookbooks from HeartyHearth.com! We have ', COUNT(CB.CookbookID), ' books for sale, average price is ', round(avg(CB.price), 2), '. You can order them all and recieve a 25% discount, for a total of ', round(sum(CB.price)*.75, 2), '.
Click <a href = "www.heartyhearth.com/order/', cast(NEWID() as varchar(255)), '>here</a> to order.')
from CookBook CB 

