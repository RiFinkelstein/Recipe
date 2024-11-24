create or alter PROCEDURE dbo.IngredientUpdate(
    @IngredientID int OUTPUT, 
    @IngredientName VARCHAR (100), 
    @message VARCHAR(500) = '' OUTPUT
)

as 
BEGIN   
    declare @return int =0

    select @IngredientID= isnull(@IngredientID, 0)

    if @IngredientID= 0
    begin 
        insert ingredient(ingredientName)
        VALUES(@IngredientName)

        SELECT @IngredientID = SCOPE_IDENTITY() 
    END

    ELSE
    BEGIN
        UPDATE ingredient
        set 
            ingredientName= @IngredientName
        where ingredientID= @IngredientID
    END

    RETURN @return


end 
go
