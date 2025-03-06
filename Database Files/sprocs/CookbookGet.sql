create or alter procedure dbo.CookbookGet (
	@CookbookID int = 0,
	@All bit= 0
	)
as
begin 
    IF @CookbookID > 0  -- Fetch a specific cookbook
	BEGIN	
--AS Why is the case necessary?
	select c.CookbookID, c.CookbookName, c.UsersID, c.Price, c.Active, c.DateCreated
	from cookbook c
	where @CookbookID= c.CookbookID or @all= 1
	order by c.CookbookName
end 
	ELSE
	    BEGIN
        SELECT
            cb.CookbookID,
            cb.CookbookName AS [Cookbook Name],
            CONCAT(u.UsersFirstName, ' ', u.UsersLastName) AS [Author],
            COUNT(CBR.RecipeID) AS [Num Recipes],
            cb.Price
        FROM Cookbook CB
        JOIN Users u ON u.UsersID = cb.UsersID
        LEFT JOIN CookbookRecipe CBR ON CBR.CookbookID = cb.CookbookID
        GROUP BY cb.CookbookID, cb.CookbookName, u.UsersFirstName, u.UsersLastName, cb.Price
        ORDER BY cb.CookbookName;
    END
END;
go

--exec dbo.CookbookGet @all= 1
--exec dbo.CookbookGet  @cookbookID = 1