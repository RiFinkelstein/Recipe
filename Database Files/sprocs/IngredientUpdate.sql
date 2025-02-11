create or alter PROCEDURE dbo.IngredientUpdate(
    @IngredientID int OUTPUT, 
    @IngredientName VARCHAR (100), 
    @Message VARCHAR(500) = '' OUTPUT
)

as 
BEGIN   
    declare @Return int =0

    select @IngredientID= isnull(@IngredientID, 0)

    if @IngredientID= 0
    begin 
        insert Ingredient(IngredientName)
        VALUES(@IngredientName)

        SELECT @IngredientID = SCOPE_IDENTITY() 
    END

    ELSE
    BEGIN
        UPDATE Ingredient
        set 
            IngredientName= @IngredientName
        where IngredientID= @IngredientID
    END

    RETURN @Return


end 
go
