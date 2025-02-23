-- SM Excellent! See comments, no need to resubmit.
use HeartyHealthDB
go 
delete CookbookRecipe
DELETE CookBook
DELETE CourseMealRecipe
DELETE CourseMeal
DELETE meal
DELETE Directions
DELETE RecipeIngredient
delete recipe 
delete course
delete Cuisine
delete Users
delete Measurement
delete ingredient
go

insert Measurement(MeasurementName)
select 'Teaspoon'
union select 'Tablespoon'
UNION SELECT 'Cup'
union select 'pound'
union select 'Ounce'
union SELECT 'Pinch'
union SELECT 'Club'
go


Insert Users(UsersFirstName, UsersLastName, UsersName)
select 'John', 'Green', 'JGreen'
union select 'Elsie', 'Bradley', 'ERadley'
union select 'Carol', 'Collins', 'CCollins'
union select 'Harris', 'Harper', 'HHarper'
union SELECT 'Brett', 'Johnson', 'BJohnson'
union select 'Aaron', 'White', 'Awhite'
union select 'Jacob', 'Elias', 'JElias'
union SELECT 'Maria', 'Stephens', 'MStephans'
union select 'Ayla', 'Bradley', 'ABradley'
go

INSERT ingredient(ingredientName)
SELECT 'sugar'
UNION SELECT 'oil'
UNION SELECT 'eggs'
UNION SELECT 'Flour'
UNION SELECT 'vanilla sugar' 
UNION SELECT 'baking powder' 
UNION SELECT 'baking soda'
UNION SELECT 'chocolate' 
UNION SELECT 'granny smith apples'
UNION SELECT 'vanilla yogurt'
UNION SELECT 'orange juice'
UNION SELECT 'honey'
UNION SELECT 'ice cubes'
UNION SELECT 'bread'
UNION SELECT 'butter'
UNION SELECT 'shredded cheese'
UNION SELECT 'cloves garlic(crushed)'
UNION SELECT 'black pepper'
UNION SELECT 'salt'
UNION SELECT 'stick butter'
UNION SELECT 'vanilla pudding'
UNION SELECT 'whipped cream cheese'
UNION SELECT 'sour cream cheese'
UNION SELECT 'onion'
UNION SELECT 'zuccini'
UNION SELECT 'carrot'
UNION SELECT 'mushrooms'
UNION SELECT 'sweet Potatoes'
UNION SELECT 'water'
UNION SELECT 'onion soup mix'
UNION SELECT 'Salmon'
UNION SELECT 'teriyaki sauce'
UNION SELECT 'brown sugar'
UNION SELECT 'ketchup'
UNION SELECT 'red pepper'
UNION SELECT 'yellow pepper'
UNION SELECT 'orange pepper'
UNION SELECT 'Can Cut up fruit'
UNION SELECT 'red apple'
UNION SELECT 'green apple'
UNION SELECT 'Whipped cream'
UNION SELECT 'bag lettuce'
UNION SELECT 'package deli'
UNION SELECT 'mayo'
UNION SELECT 'mustard'
UNION SELECT 'chicken'
UNION SELECT 'Bag of Pretzels'
UNION SELECT 'Rice'
UNION SELECT 'Chicken soup mix'
UNION SELECT 'chocolate'
UNION SELECT 'Egg whites'
UNION SELECT 'Milk'
UNION SELECT 'Big Potatoes'
UNION SELECT 'rich''s Whip'
Union SELECT 'chocolate chips'
union SELECT 'bananas'
union select 'lemon juice'
GO

INSERT Cuisine(CuisineName)
SELECT 'French'
UNION SELECT 'Italian'
UNION SELECT 'Chinese'
UNION SELECT 'Japanese'
UNION SELECT 'Greek'
UNION SELECT 'Indian' 
UNION SELECT 'Spanish'
UNION SELECT 'American'
UNION SELECT 'English' 
UNION SELECT 'Jewish'
UNION SELECT 'Mexican'
go 

insert course(CourseName, CourseSequence)
SELECT 'soup', 1
union select 'appetizer', 2
union select 'salad', 3
union select 'Main Course', 4 
union select 'Dessert', 5
GO


-- SM A CTE would be much more readable and easier to do.
insert Recipe(UsersID, CuisineID, RecipeName, calories, DraftedDate, PublishedDate, ArchivedDate)
SELECT (Select u.usersID from users U WHERE UsersName = 'JGreen'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'Chocolate Chip Cookies', 150, '12-30-2003', '07-14-2013', '01-07-2016' 
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'ERadley'), (select C.CuisineID from Cuisine C where cuisinename= 'French'), 'Apple Yogurt Smoothie', 75, '05-28-2004', '04-11-2009',  null 
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'CCollins'), (select C.CuisineID from Cuisine C where cuisinename= 'English'), 'Cheese Bread', 250, '11-01-2021', null,  null 
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'CCollins'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'Vegetable Soup', 50, '02-22-2015', '02-16-2022',  '04-04-2022'
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'HHarper'), (select C.CuisineID from Cuisine C where cuisinename= 'Japanese'), 'Teriaki Salmon', 400, '11-07-2009', '09-05-2022', null
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'BJohnson'), (select C.CuisineID from Cuisine C where cuisinename= 'Mexican'), 'Grilled Peppers', 40, '07-29-2008', '05-22-2009', '08-26-2016'
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'Awhite'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'Fruit Cups', 100, '09-25-2023', null, null
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'JElias'), (select C.CuisineID from Cuisine C where cuisinename= 'Jewish'), 'Deli Salad', 100, '10-11-2008', '01-26-2013', '08-21-2021'
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'MStephans'), (select C.CuisineID from Cuisine C where cuisinename= 'Jewish'), 'Pretzel Chicken ', 120, '06-16-2019', '06-16-2020', null
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'MStephans'), (select C.CuisineID from Cuisine C where cuisinename= 'Japanese'), 'Spicy Rice', 120, '12-21-2003', '01-30-2008', '03-26-2017'
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'CCollins'), (select C.CuisineID from Cuisine C where cuisinename= 'French'), 'Chocolate Mousse', 175, '05-20-2015', null, '05-10-2019'
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'CCollins'), (select C.CuisineID from Cuisine C where cuisinename= 'Greek'), 'pancakes', 125, '09-12-2020', null, null
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'ERadley'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'Classic Potatoes', 125, '09-09-2005', '02-08-2010', null
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'JGreen'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'Vanilla Ice Cream', 150, '03-28-2001', '01-15-2003', '07-27-2017' 
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'ERadley'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'baked banana chips', 25, '06-17-2003', '06-05-2010', '11-04-2023'
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'MStephans'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'CC Muffins ', 300, '01-20-2012', '01-11-2016', '12-03-2021'
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'MStephans'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'Cinaman Butter Muffins ', 300, '01-20-2012', '01-11-2016', '12-03-2021'
UNION SELECT (Select u.usersID from users U WHERE UsersName = 'MStephans'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'PeanutButter Muffins ', 300, '01-20-2012', '01-11-2016', '12-03-2021'
go

-- SM A CTE would be much more readable and easier to do.
Insert RecipeIngredient(RecipeID, IngredientID, MeasurementID, Amount, SequenceNumber)
select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), (select I.ingredientID from ingredient I where I.ingredientName= 'Sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), (select I.ingredientID from ingredient I where I.ingredientName= 'oil'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), .5, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), (select I.ingredientID from ingredient I where I.ingredientName= 'eggs'), null, 3, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), (select I.ingredientID from ingredient I where I.ingredientName= 'flour'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 2, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), (select I.ingredientID from ingredient I where I.ingredientName= 'vanilla sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teasponn'), 1, 5
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), (select I.ingredientID from ingredient I where I.ingredientName= 'baking powder'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teasponn'), 2, 6
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), (select I.ingredientID from ingredient I where I.ingredientName= 'baking soda'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teasponn'), .5, 7
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), (select I.ingredientID from ingredient I where I.ingredientName= 'chocolate chips'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 8
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), (select I.ingredientID from ingredient I where I.ingredientName= 'granny smith apples'), null, 3, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), (select I.ingredientID from ingredient I where I.ingredientName= 'vanilla yogurt'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 2, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), (select I.ingredientID from ingredient I where I.ingredientName= 'sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teaspoon'), 2, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), (select I.ingredientID from ingredient I where I.ingredientName= 'orange juice'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), .5, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), (select I.ingredientID from ingredient I where I.ingredientName= 'honey'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teaspoon'), 2, 5
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), (select I.ingredientID from ingredient I where I.ingredientName= 'Ice Cubes'), null, 5, 6
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), (select I.ingredientID from ingredient I where I.ingredientName= 'Bread'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Club'), 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), (select I.ingredientID from ingredient I where I.ingredientName= 'Butter'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Ounce'), 4, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), (select I.ingredientID from ingredient I where I.ingredientName= 'Shredded Cheese'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Ounce'), 8, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), (select I.ingredientID from ingredient I where I.ingredientName= 'cloves garlic(crushed)'), null , 1, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), (select I.ingredientID from ingredient I where I.ingredientName= 'Black Pepper'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teaspoon'), .25, 5
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), (select I.ingredientID from ingredient I where I.ingredientName= 'Salt'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Pinch'), 1, 6
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), (select I.ingredientID from ingredient I where I.ingredientName= 'Onion'), null, 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), (select I.ingredientID from ingredient I where I.ingredientName= 'Zuccini'), null, 2, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), (select I.ingredientID from ingredient I where I.ingredientName= 'Carrot'), null, 3, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), (select I.ingredientID from ingredient I where I.ingredientName= 'Mushrooms'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Ounce'), 4, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), (select I.ingredientID from ingredient I where I.ingredientName= 'Sweet Potatoes'), null, 2, 5
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), (select I.ingredientID from ingredient I where I.ingredientName= 'Water'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Cup'), 8, 6
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), (select I.ingredientID from ingredient I where I.ingredientName= 'Salt'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpoon'), 1, 7
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), (select I.ingredientID from ingredient I where I.ingredientName= 'Onion Soup Mix'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpoon'), 3, 8
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Teriaki Salmon'), (select I.ingredientID from ingredient I where I.ingredientName= 'Salmon'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'pound'), 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Teriaki Salmon'), (select I.ingredientID from ingredient I where I.ingredientName= 'teriyaki sauce'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Teriaki Salmon'), (select I.ingredientID from ingredient I where I.ingredientName= 'Brown Sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), .5, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Teriaki Salmon'), (select I.ingredientID from ingredient I where I.ingredientName= 'ketchup'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), .5, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Grilled Peppers'), (select I.ingredientID from ingredient I where I.ingredientName= 'red pepper'), null, 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Grilled Peppers'), (select I.ingredientID from ingredient I where I.ingredientName= 'yellow pepper'), null, 1, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Grilled Peppers'), (select I.ingredientID from ingredient I where I.ingredientName= 'orange pepper'), null, 1, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Grilled Peppers'), (select I.ingredientID from ingredient I where I.ingredientName= 'teriyaki sauce'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Sauce'), .5, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Fruit Cups'), (select I.ingredientID from ingredient I where I.ingredientName= 'Can Cut up fruit'), null, 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Fruit Cups'), (select I.ingredientID from ingredient I where I.ingredientName= 'Red Apple'), null, 1, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Fruit Cups'), (select I.ingredientID from ingredient I where I.ingredientName= 'Green Apple'), null, 1, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Fruit Cups'), (select I.ingredientID from ingredient I where I.ingredientName= 'Rich''s Whip'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'ounce'), 8, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), (select I.ingredientID from ingredient I where I.ingredientName= 'Bag Lettuce'), null, 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), (select I.ingredientID from ingredient I where I.ingredientName= 'Package Deli'), null, 1, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), (select I.ingredientID from ingredient I where I.ingredientName= 'Red Pepper'), null, 1, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), (select I.ingredientID from ingredient I where I.ingredientName= 'Mayo'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), (select I.ingredientID from ingredient I where I.ingredientName= 'Mustard'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpook'), 2, 5
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), (select I.ingredientID from ingredient I where I.ingredientName= 'Water'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), .25, 6
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), (select I.ingredientID from ingredient I where I.ingredientName= 'Sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), .25, 7
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), (select I.ingredientID from ingredient I where I.ingredientName= 'Chicken'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'pound'), 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), (select I.ingredientID from ingredient I where I.ingredientName= 'Bag of Pretzels'), null, 1, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), (select I.ingredientID from ingredient I where I.ingredientName= 'eggs'), null, 2, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), (select I.ingredientID from ingredient I where I.ingredientName= 'Flour'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Spicy Rice'), (select I.ingredientID from ingredient I where I.ingredientName= 'Rice'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Spicy Rice'), (select I.ingredientID from ingredient I where I.ingredientName= 'Water'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 2, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Spicy Rice'), (select I.ingredientID from ingredient I where I.ingredientName= 'Salt'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teaspoon'), 1, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Spicy Rice'), (select I.ingredientID from ingredient I where I.ingredientName= 'Black Pepper'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teaspoon'), .5, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Spicy Rice'), (select I.ingredientID from ingredient I where I.ingredientName= 'Chicken Soup Mix'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpoon'), 2, 5
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Mousse'), (select I.ingredientID from ingredient I where I.ingredientName= 'Chocolate'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), .75, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Mousse'), (select I.ingredientID from ingredient I where I.ingredientName= 'Egg Whites'), null, 6, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Mousse'), (select I.ingredientID from ingredient I where I.ingredientName= 'Sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpoon'), 2, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'pancakes'), (select I.ingredientID from ingredient I where I.ingredientName= 'Sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpoon'), 2, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'pancakes'), (select I.ingredientID from ingredient I where I.ingredientName= 'flour'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'pancakes'), (select I.ingredientID from ingredient I where I.ingredientName= 'eggs'), null, 1, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'pancakes'), (select I.ingredientID from ingredient I where I.ingredientName= 'milk'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), .75, 4
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Classic Potatoes'), (select I.ingredientID from ingredient I where I.ingredientName= 'Big Potatoes'), null, 4, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Classic Potatoes'), (select I.ingredientID from ingredient I where I.ingredientName= 'oil'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Classic Potatoes'), (select I.ingredientID from ingredient I where I.ingredientName= 'Onion Soup Mix'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpoon'), 5, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vanilla Ice Cream'), (select I.ingredientID from ingredient I where I.ingredientName= 'Rich''s whip'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'ounce'), 8, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vanilla Ice Cream'), (select I.ingredientID from ingredient I where I.ingredientName= 'sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cup'), 1, 2
union Select (select r.RecipeID from recipe R where r.RecipeName = 'Vanilla Ice Cream'), (select I.ingredientID from ingredient I where I.ingredientName= 'egg whites'), null, 3, 3
union Select (select r.RecipeID from recipe R where r.RecipeName = 'baked banana chips'), (select I.ingredientID from ingredient I where I.ingredientName= 'bananas'), null, 2, 1
union Select (select r.RecipeID from recipe R where r.RecipeName = 'baked banana chips'), (select I.ingredientID from ingredient I where I.ingredientName= 'Lemon Juice'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpoon'), 3, 2
--union Select (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), (select I.ingredientID from ingredient I where I.ingredientName= 'Stick Butter'), null, 1, 1
--union Select (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), (select I.ingredientID from ingredient I where I.ingredientName= 'Sugar'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Cup'), 3, 2
--union Select (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), (select I.ingredientID from ingredient I where I.ingredientName= 'Vanilla Pudding'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'TableSpoon'), 2, 3
--union Select (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), (select I.ingredientID from ingredient I where I.ingredientName= 'eggs'), null, 4, 4
--union Select (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), (select I.ingredientID from ingredient I where I.ingredientName= 'whipped cream cheese'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'ounce'), 8, 5
--union Select (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), (select I.ingredientID from ingredient I where I.ingredientName= 'sour cream cheese'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'ounce'), 8, 6
--union Select (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), (select I.ingredientID from ingredient I where I.ingredientName= 'flour'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'cups'), 1, 7
--union Select (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), (select I.ingredientID from ingredient I where I.ingredientName= 'baking powder'), (select M.MeasurementID from Measurement m where m.MeasurementName= 'Teaspoon'), 2, 8
GO

---- SM A CTE would be much more readable and easier to do.
insert Directions(RecipeID, Direction, StepNumber)
SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), 'First combine sugar, oil and eggs in a bowl', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), 'mix well', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), 'add flour, vanilla sugar, baking powder and baking soda', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), 'beat for 5 minutes', 4
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), 'add chocolate chips', 5
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), 'freeze for 1-2 hours', 6
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), 'roll into balls and place spread out on a cookie sheet', 7
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Chip Cookies'), 'bake on 350 for 10 min.', 8
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), 'Peel the apples and dice', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), 'Combine all ingredients in bowl except for apples and ice cubes',2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), 'mix until smooth', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), 'add apples and ice cubes', 4
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Apple Yogurt Smoothie'), 'pour into glasses.', 5
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), 'Slit bread every 3/4 inch', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), 'Combine all ingredients in bowl', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), 'fill slits with cheese mixture', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Cheese Bread'), ' wrap bread into a foil and bake for 30 minutes.', 4
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), 'saute onion in pot', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), 'cut up rest of vegetables', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), 'add vegetables, water and spices to pot', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Vegetable Soup'), 'Put on high flame until reaches boiling bring to simmer for 3 hours', 4
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Teriaki Salmon'), 'mix all ingredients besides salmon together', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Teriaki Salmon'), 'pour over salmon', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Teriaki Salmon'), 'bake at 400 F for 12-15 minutes', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Grilled Peppers'), 'cut up peppers', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Grilled Peppers'), 'mix with teriyaki sauce', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Grilled Peppers'), 'grill', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Fruit Cups'), 'cut up both apples', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Fruit Cups'), 'Mix apples with canned fruit', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Fruit Cups'), 'Whip the Rich''s Whip', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Fruit Cups'), 'Put the Whip on top of the fruit', 4
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), 'Cut lettuce, deli and pepper and put in bowl', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), 'mix the rest of the ingredients in a separate bowl for dressing ', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Deli Salad'), 'pour dressing over salad and mix', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), 'cut the chicken into shnitzel shape', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), 'Coat the chicken in flour', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), 'dip the chicken into egg', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), 'crush pretzels', 4
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), 'coat the chicken into crushed pretzels', 5
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Pretzel Chicken '), 'fry', 6
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Spicy Rice'), 'put all ingredietns in a pan ', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Spicy Rice'), 'cook on 350F for an hour covered', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Mousse'), 'melt the chocoale', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Mousse'), 'whisk the eggs', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Mousse'), 'add in the sugar to the whipped eggs', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Chocolate Mousse'), 'add egg whites to the melted chocolate', 4
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'pancakes'), 'mix all ingredients together', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'pancakes'), 'fry the batter into whatever shapes you want', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Classic Potatoes'), 'Cut up the potatoes', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Classic Potatoes'), 'pour oil and onion soupmix on top', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Classic Potatoes'), 'Cook on 400 F for 1 hours', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Vanilla Ice Cream'), 'Whip up Rich''s Whip ', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Vanilla Ice Cream'), 'Whip Egg Whites', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Vanilla Ice Cream'), 'Mix together and add sugar', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Vanilla Ice Cream'), 'freeze', 4
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'baked banana chips'), 'slice bananas and put on baking sheet', 1
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'baked banana chips'), 'brush bananas with lemon juice', 2
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'baked banana chips'), 'check on bananas and lift them from paper so they dont stick ', 3
UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'baked banana chips'), 'bake until dry (for another 30-60 minutes)', 4
--UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), 'Cream butter with sugars', 1
--UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), 'Add eggs and mix well', 2
--UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), 'Slowly add rest of ingredients and mix well', 3
--UNION SELECT (select r.RecipeID from recipe R where r.RecipeName = 'Butter Muffins'), 'fill muffin pans 3/4 full and bake for 30 minutes.', 4

-- SM A CTE would be much more readable and easier to do.
insert meal(UsersID, MealName, active, DateCreated)
SELECT (Select u.usersID from users U WHERE UsersName = 'JGreen'), 'BreakFast Bash', 1,  '07-14-2013'
union SELECT (Select u.usersID from users U WHERE UsersName = 'JGreen'), 'Savory Lunch', 0,  '02-15-2012'
union SELECT (Select u.usersID from users U WHERE UsersName = 'HHarper'), 'Filling Dinner', 1,  '12-22-2023'
union SELECT (Select u.usersID from users U WHERE UsersName = 'Awhite'), 'Bunch oh Brunch ', 1,  '07-02-2022'
go

;with x as (
    select MealName= 'BreakFast Bash', Coursename= 'Main Course'
    union select 'BreakFast Bash', 'Appetizer'
    union select 'Savory Lunch', 'Appetizer'
    union select 'Savory Lunch','Main Course'
    union select 'Savory Lunch', 'Dessert'
    union select 'Filling Dinner', 'Appetizer'
    union select 'Filling Dinner','Main Course'
    union select 'Filling Dinner', 'Dessert'    
    union select 'Bunch oh Brunch', 'Appetizer'
    union select 'Bunch oh Brunch','Main Course'
    union select 'Bunch oh Brunch', 'Dessert'

)
Insert CourseMeal(CourseID, MealID)
select c.courseID, M.MealID
from x 
join course c
on x.coursename = c.coursename
join Meal M 
on M.MealName =x.MealName


;with x as(
    SELECT  MealName= 'BreakFast Bash', Coursename= 'Main Course', RecipeName='Cheese Bread', MainDish= 1
    union select 'BreakFast Bash', 'Main Course', 'Butter Muffins', 0 
    union select 'BreakFast Bash', 'Appetizer', 'Apple Yogurt Smoothie', 0
    union select 'Savory Lunch', 'Appetizer', 'Vegetable soup', 0
    union select 'Savory Lunch','Main Course', 'Teriaki Salmon', 1
    union select 'Savory Lunch','Main Course', 'Grilled peppers', 0
    union select 'Savory Lunch', 'Dessert', 'Fruit Cups', 0
    union select 'Filling Dinner', 'Appetizer', 'Deli Salad', 0
    union select 'Filling Dinner','Main Course', 'Pretzel Chicken', 1
    union select 'Filling Dinner','Main Course', 'Spicy Rice', 0
    union select 'Filling Dinner', 'Dessert', 'Chocolate Mousse', 0
    union select 'Bunch oh Brunch', 'Appetizer', 'Fruit cups', 0
    union select 'Bunch oh Brunch','Main Course', 'yogurt smoothie', 1
    union select 'Bunch oh Brunch','Main Course', 'pancakes', 1
    union select 'Bunch oh Brunch','Main Course', 'Classic Potatoes', 0
    union select 'Bunch oh Brunch', 'Dessert', 'Vanilla Ice Cream', 0
)
INSERT CourseMealRecipe(CourseMealID, RecipeID, MaidDish)
SELECT CourseMealID, R.RecipeID, x.Maindish
from x 
join course c 
on c.CourseName = x.Coursename
join meal M 
on m.MealName = x.MealName
join CourseMeal CM
on c.CourseID = cm.CourseID and m.MealID=cm.MealID
join recipe R 
on r.RecipeName = x.RecipeName
go

-- SM A CTE would be much more readable and easier to do.
INSERT CookBook (UsersID, CookbookName, price, DateCreated, Active)
SELECT (Select u.usersID from users U WHERE UsersName = 'JGreen'), 'Treats for two', 30,  '07-14-2013', 1
union SELECT (Select u.usersID from users U WHERE UsersName = 'JElias'), 'Deserts Oh my', 35,  '09-23-21', 1
union SELECT (Select u.usersID from users U WHERE UsersName = 'JGreen'), 'Best of Recipes', 25,  '02-15-2022', 1
union SELECT (Select u.usersID from users U WHERE UsersName = 'Awhite'), 'Kid in the kitchen', 15,  '11-10-2021', 0
GO
  
;with x as(
    select CookBookname= 'Treats for two', RecipeName= 'Chocolate Chip Cookies', sequencenumber= 1
    union select CookBookname= 'Treats for two', RecipeName= 'Apple Yogurt Smoothie', sequencenumber= 2
    union select CookBookname= 'Treats for two', RecipeName= 'Cheese Bread', sequencenumber= 3
    union select CookBookname= 'Treats for two', RecipeName= 'Butter Muffins', sequencenumber= 4
    union select CookBookname= 'Deserts Oh my', RecipeName= 'Chocolate Mousse', sequencenumber= 1
    union select CookBookname= 'Deserts Oh my', RecipeName= 'Vanilla Ice Cream', sequencenumber= 2
    union select CookBookname= 'Deserts Oh my', RecipeName= 'Pancakes', sequencenumber= 3
    union select CookBookname= 'Deserts Oh my', RecipeName= 'Fruit Cups', sequencenumber= 4
    union select CookBookname= 'Best of Recipes', RecipeName= 'Deli Salad', sequencenumber= 1
    union select CookBookname= 'Best of Recipes', RecipeName= 'Pretzel Chicken', sequencenumber= 2
    union select CookBookname= 'Best of Recipes', RecipeName= 'Teriaki Salmon', sequencenumber= 3
    union select CookBookname= 'Best of Recipes', RecipeName= 'Spicy rice', sequencenumber= 4
    union select CookBookname= 'Best of Recipes', RecipeName= 'Classic Potatoes', sequencenumber= 5
    union select CookBookname= 'Kid in the Kitchen', RecipeName= 'Vanilla Ice Cream', sequencenumber= 1
    union select CookBookname= 'Kid in the Kitchen', RecipeName= 'Pancakes', sequencenumber= 2
    union select CookBookname= 'Kid in the Kitchen', RecipeName= 'Fruit Cups', sequencenumber= 3
    union select CookBookname= 'Kid in the Kitchen', RecipeName= 'Classic Potatoes', sequencenumber= 4
)
INSERT CookbookRecipe(cookbookID, RecipeID, CookBookSequenceNumber)
SELECT C.cookbookID, r.RecipeID, x.sequencenumber
from x 
join cookbook C
on c.CookbookName = x.CookbookName
join Recipe R
on r.Recipename = x.Recipename
go 



