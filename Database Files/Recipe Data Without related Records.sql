use HeartyHealthDB

drop table if EXISTS recipe


CREATE table dbo.recipe(
    RecipeID int not null Identity PRIMARY KEY,
    RecipeName varchar(50)
            CONSTRAINT ck_Recipe_Recipe_name_is_not_blank check(RecipeName <> '') 
            constraint u_Recipe_Recipe_name_is_unique UNIQUE,
    Calories int not null constraint ck_calories_not_less_than_0 CHECK(calories>0), 
    DraftedDate DATETIME not null,
    PublishedDate DATETIME null,
    ArchivedDate DATETIME null,
    Picure as concat('recipe_', replace(RecipeName, ' ', '_'), '.jpg'),
    Status as case
        when PublishedDate is null and ArchivedDate is null then 'Drafted' 
        when PublishedDate is not null and ArchivedDate is null then 'Published'
        else 'Archived' 
        end
    )
go 


delete recipe 


insert Recipe(RecipeName, calories, DraftedDate, PublishedDate, ArchivedDate)
SELECT 'Chocolate Chip Cookies', 150, '12-30-2003', '07-14-2013', '01-07-2016' 
UNION SELECT 'Apple Yogurt Smoothie', 75, '05-28-2004', '04-11-2009',  null 
UNION SELECT 'Cheese Bread', 250, '11-01-2021', null,  null 
UNION SELECT 'Vegetable Soup', 50, '02-22-2015', '02-16-2022',  '04-04-2022'
UNION SELECT 'Teriaki Salmon', 400, '11-07-2009', '09-05-2022', null
UNION SELECT 'Grilled Peppers', 40, '07-29-2008', '05-22-2009', '08-26-2016'
UNION SELECT  'Fruit Cups', 100, '09-25-2023', null, null
UNION SELECT 'Deli Salad', 100, '10-11-2008', '01-26-2013', '08-21-2021'
UNION SELECT 'Pretzel Chicken ', 120, '06-16-2019', '06-16-2020', null
UNION SELECT 'Spicy Rice', 120, '12-21-2003', '01-30-2008', '03-26-2017'
UNION SELECT 'Chocolate Mousse', 175, '05-20-2015', null, '05-10-2019'
UNION SELECT 'pancakes', 125, '09-12-2020', null, null
UNION SELECT 'Classic Potatoes', 125, '09-09-2005', '02-08-2010', null
UNION SELECT  'Vanilla Ice Cream', 150, '03-28-2001', '01-15-2003', '07-27-2017' 
UNION SELECT 'baked banana chips', 25, '06-17-2003', '06-05-2010', '11-04-2023'
UNION SELECT 'Butter Muffins', 300, '01-20-2012', '01-11-2016', '12-03-2021'
go


