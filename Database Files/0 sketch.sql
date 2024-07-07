-- SM Excellent sketch! See comments, no need to resubmit. Good luck on creating the DB.
/*
Users
    primary key
    firstname varchar not blank
    lastname varchar not blank
    username varchar not blank unique


ingredient
    primarykey 
    ingredient name varchar, unique, cant be blank 
    computed column- picture

recipe 
    Primarykey
    cuisineID foreign key
    userID foreign key 
    RecipeName varchar not blank unique
	calories int not less than 0 
    DraftedDate date not null not blank 
    PublishedDate date null 
    Archived date null 
    computed column- picture
    Status varchar not null computed based on drafted/published/archived
    constraint Published date could not be before drafted date and archived date needs to be after both published and archived
    

Cuisne
    primarykey 
    cuisne name varchar uniqe cant be blank

Recipeingredient
    primarykey 
    recipeID foreign key 
    ingredientID foreign key 
    measurementID foreignkey 
    amount int not null not less than 0 
    sequence int not null not less than 0 
    constraints: recipeID and ingredientID unique
                sequence# and recipeID is unique

Measurement
    primarykey 
    MeasurmentName varchar not null not blank unique 

Directions
    primary key primary key 
    recipeID foreign key 
    direction not null not blank 
    step number int not null not less than 0 
    constraint: direction# and recipeID    

meal
    primary key 
    userID foreign key 
    MealName unique varchar not blank 
    active? bit 
    DateCreated date not null not blank 
    computed column- picture

Course
    primarykey 
    courseName varchar not blank unique
    sequence int not less than 0 unique
    

CourseMeal
    primarykey 
    courseID forein key
    mealID  foreign key 
    constraint: mealID, courseID unique

CourseMealRecipe
    primarykey
    coursemealID foreign key
    recipeID foreign key
    main dish bit
    constraint: coursemealID and RecipeID
	
cookbook 
    primarykey 
    userID foreign key 
    name varchar not null not blank unique
    price decimal not null not les than 0 
    DateCreated date not null not blank 
    Acitve? bit  
    computed column- picture
    
CookbookRecipe
    primary key 
    cookbookID foreign key 
    recipeID foreign key
    sequence# int not null  not less than 0 
    constraint: cookbookID and recipeID unique
                cookbook and sequenece # unique 

*/
