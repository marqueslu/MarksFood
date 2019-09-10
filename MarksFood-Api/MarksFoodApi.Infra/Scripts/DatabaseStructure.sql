CREATE DATABASE MarksFood
GO

USE MarksFood;
GO

CREATE TABLE Ingredient(
	[Id]	UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	[Name]	VARCHAR(30) NOT NULL,
	[Price] MONEY NOT NULL
)
GO

CREATE TABLE Snack(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE SnackIngredients(
	IdSnack UNIQUEIDENTIFIER NOT NULL,
	IdIngredient UNIQUEIDENTIFIER NOT NULL,
	Quantity SMALLINT NOT NULL,
	FOREIGN KEY ([IdSnack]) REFERENCES [Snack]([Id]),
	FOREIGN KEY ([IdIngredient]) REFERENCES [Ingredient]([Id]),
)
GO

CREATE TABLE Discount(
	Id UNIQUEIDENTIFIER NOT NULL,
	Name VARCHAR(30) NOT NULL,
	IdIngredientAllowed UNIQUEIDENTIFIER NOT NULL,
	IdIngredientRestrict UNIQUEIDENTIFIER,
	DiscountType INT NOT NULL,
	Quantity INT,
	[Percent] DECIMAL(5,2) NOT NULL,
	Active BIT NOT NULL,
	FOREIGN KEY([IdIngredientAllowed]) REFERENCES [Ingredient]([Id]),
	FOREIGN KEY([IdIngredientRestrict]) REFERENCES [Ingredient]([Id])
)
GO


CREATE PROCEDURE [dbo].[SP_Snack_Insert]
	@Id UNIQUEIDENTIFIER,
	@Name VARCHAR(50) 
AS
BEGIN
	INSERT INTO Snack(Id, Name) 
	VALUES(@Id, @Name)
END
GO
GO

CREATE PROCEDURE SP_Snack_Update 
	@Id   UNIQUEIDENTIFIER, 
    @Name VARCHAR(50) 
AS 
  BEGIN 
      UPDATE snack 
      SET    NAME = @Name 
      WHERE  id = @Id 
  END 
GO

CREATE PROCEDURE SP_discount_Select 
	@IdIngredientAllowed UNIQUEIDENTIFIER 
AS 
  BEGIN 
      SELECT id, 
             NAME, 
             idingredientallowed, 
             idingredientrestrict, 
             quantity, 
             [percent] 
      FROM   discount 
      WHERE  idingredientallowed = @IdIngredientAllowed 
  END
GO

CREATE PROCEDURE SP_Get_Snack_ById
	@Id UNIQUEIDENTIFIER
AS
	BEGIN
		SELECT [Id], [Name] FROM [Snack] WHERE Id = @Id
	END
GO

CREATE PROCEDURE SP_Ingredient_Select
AS
	BEGIN
		SELECT [Id], [Name], [Price] FROM Ingredient
	END
GO	

CREATE PROCEDURE SP_Snack_Select
AS
	BEGIN
		SELECT Id, Name from Snack
	END
GO

CREATE PROCEDURE SP_SnackIngredients_Select
	@IdSnack UNIQUEIDENTIFIER
AS
	BEGIN
		SELECT 			   
			   I.id, 
			   I.NAME, 
			   I.price, 
			   SI.quantity 
		FROM   snackingredients AS SI 
			   INNER JOIN snack AS S 
					   ON SI.idsnack = S.id 
			   INNER JOIN ingredient AS I 
					   ON SI.idingredient = I.id 
		WHERE  si.idsnack = @IdSnack 
	END
GO

CREATE PROCEDURE SP_SnackIngredient_Insert
	@IdIngredient UNIQUEIDENTIFIER,
	@IdSnack UNIQUEIDENTIFIER,
	@Quantity SMALLINT
AS
	BEGIN
		INSERT INTO SnackIngredients(IdIngredient, IdSnack, Quantity)
		VALUES (@IdIngredient, @IdSnack, @Quantity)
	END
GO

CREATE PROCEDURE SP_SnackIngredient_Update
	@IdIngredient UNIQUEIDENTIFIER,
	@IdSnack UNIQUEIDENTIFIER,
	@Quantity SMALLINT
AS
	BEGIN
		DELETE FROM SnackIngredients 
		WHERE IdSnack = @IdSnack

		INSERT INTO SnackIngredients(IdIngredient, IdSnack, Quantity)
		VALUES (@IdIngredient, @IdSnack, @Quantity)
	END
GO