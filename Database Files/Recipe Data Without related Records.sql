use HeartyHealthDB


insert Recipe(UsersID, CuisineID, RecipeName, calories, DraftedDate, PublishedDate, ArchivedDate)
SELECT (Select u.usersID from users U WHERE UserName = 'MStephans'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'CC Muffins ', 300, '01-20-2012', '01-11-2016', '12-03-2021'
UNION SELECT (Select u.usersID from users U WHERE UserName = 'MStephans'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'Cinaman Butter Muffins ', 300, '01-20-2012', '01-11-2016', '12-03-2021'
UNION SELECT (Select u.usersID from users U WHERE UserName = 'MStephans'), (select C.CuisineID from Cuisine C where cuisinename= 'American'), 'PanutButter Muffins ', 300, '01-20-2012', '01-11-2016', '12-03-2021'




