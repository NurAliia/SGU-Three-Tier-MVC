CREATE PROCEDURE [dbo].[sp_InsertShop]   
	@NameShop nvarchar(200), 
    @Address nvarchar(200),
	@IDCity int,
	@WebSite nvarchar(50),
	@DescriptionShop nvarchar(200),
	@PhoneShop nvarchar(12),
	@OpeningHours nvarchar(50)
	
AS
	SET NOCOUNT ON;
    INSERT INTO [dbo].[Shop] (NameShop, [Address], IDCity, WebSite,DescriptionShop,PhoneShop,OpeningHours)
    VALUES ( @NameShop,@Address,@IDCity, @WebSite, @DescriptionShop,@PhoneShop,@OpeningHours)
GO


CREATE PROCEDURE [dbo].[sp_GetShops]
AS		
    SELECT 
	[dbo].[Shop].IDShop,
	[dbo].[Shop].NameShop,
	[dbo].[Shop].[Address], 
	[dbo].[City].NameCity, 
	[dbo].[Shop].Website,
	[dbo].[Shop].DescriptionShop,
	[dbo].[Shop].PhoneShop,
	[dbo].[Shop].OpeningHours
	FROM [dbo].[Shop] 
	JOIN City on Shop.IdCity = City.IDCity
GO

CREATE PROCEDURE [dbo].[sp_GetShopsByModerator]	
	@IDModerator INT
AS	
    SELECT 
	[dbo].[Shop].IDShop,
	[dbo].[Shop].NameShop,
	[dbo].[Shop].[Address], 
	[dbo].[City].NameCity, 
	[dbo].[Shop].Website,
	[dbo].[Shop].DescriptionShop,
	[dbo].[Shop].PhoneShop,
	[dbo].[Shop].OpeningHours
	FROM [dbo].[Shop] 
	JOIN City on Shop.IdCity = City.IDCity
	JOIN Moderator on Shop.IDShop = Moderator.IDShop
	Where [dbo].[Moderator].IDUser=@IDModerator
GO

CREATE PROCEDURE [dbo].[sp_GetShopByCity]
	 @IDCity INT
AS	
	SELECT 
	[dbo].[Shop].IDShop,
	[dbo].[Shop].NameShop,
	[dbo].[Shop].[Address], 
	[dbo].[City].NameCity, 
	[dbo].[Shop].Website,
	[dbo].[Shop].DescriptionShop,
	[dbo].[Shop].PhoneShop,
	[dbo].[Shop].OpeningHours
	FROM [dbo].[Shop] 
	JOIN City on Shop.IdCity = City.IDCity
	Where [dbo].[Shop].IDCity = @IDCity
GO

CREATE PROCEDURE [dbo].[sp_GetShopsByDescription]
	 @DescriptionShop nvarchar(200)
AS	
	SELECT 
	[dbo].[Shop].IDShop,
	[dbo].[Shop].NameShop,
	[dbo].[Shop].[Address], 
	[dbo].[City].NameCity, 
	[dbo].[Shop].Website,
	[dbo].[Shop].DescriptionShop,
	[dbo].[Shop].PhoneShop,
	[dbo].[Shop].OpeningHours
	FROM [dbo].[Shop] 
	JOIN City on Shop.IdCity = City.IDCity
	Where [dbo].[Shop].DescriptionShop = @DescriptionShop
GO

CREATE PROCEDURE [dbo].[sp_GetShopsByName]
	 @NameShop nvarchar(200)
AS	
	SELECT 
	[dbo].[Shop].IDShop,
	[dbo].[Shop].NameShop,
	[dbo].[Shop].[Address], 
	[dbo].[City].NameCity, 
	[dbo].[Shop].Website,
	[dbo].[Shop].DescriptionShop,
	[dbo].[Shop].PhoneShop,
	[dbo].[Shop].OpeningHours
	FROM [dbo].[Shop] 
	JOIN City on Shop.IdCity = City.IDCity
	Where [dbo].[Shop].NameShop = @NameShop
GO

CREATE PROCEDURE [dbo].[sp_GetShopById]
	 @IDShop INT
AS	
	SELECT 
	[dbo].[Shop].IDShop,
	[dbo].[Shop].NameShop,
	[dbo].[Shop].[Address], 
	[dbo].[City].NameCity, 
	[dbo].[Shop].Website,
	[dbo].[Shop].DescriptionShop,
	[dbo].[Shop].PhoneShop,
	[dbo].[Shop].OpeningHours
	FROM [dbo].[Shop] 
	JOIN City on Shop.IdCity = City.IDCity
	Where [dbo].[Shop].IDShop = @IDShop
GO

CREATE PROCEDURE [dbo].[sp_UpdateShop]
	 @IDShop int,
	 @NameShop nvarchar(200),
	 @Address nvarchar(200),
	 @City nvarchar(100),
	 @Website nvarchar(50),
	 @DescriptionShop nvarchar(200),
	 @PhoneShop nvarchar(12),
	 @OpeningHours nvarchar(50)
AS
	Declare @IDCity int
	SELECT @IDCity=IDCity from City Where NameCity = @City
	UPDATE [dbo].[Shop] 
	SET
	NameShop=@NameShop,
	[Address]=@Address,
	IDCity=@IDCity,
	Website= @Website,
	DescriptionShop=@DescriptionShop,
	PhoneShop = @PhoneShop,
	OpeningHours = @OpeningHours
	Where IDShop = @IDShop
GO


CREATE PROCEDURE [dbo].[sp_DeleteShop]
	 @IDShop int
AS
	DELETE FROM [dbo].[Shop] Where IDShop = @IDShop
GO 



DROP PROCEDURE [sp_InsertShop] 
GO 
DROP PROCEDURE [sp_GetShops]
GO 
DROP PROCEDURE [sp_GetShopsByModerator]
GO
DROP PROCEDURE [sp_GetShopByCity]
GO 
DROP PROCEDURE [dbo].[sp_GetShopsByDescription] 
GO 
DROP PROCEDURE [sp_GetShopsByName]  
GO 
DROP PROCEDURE [dbo].[sp_GetShopById]
GO
DROP PROCEDURE [dbo].[sp_UpdateShop]
Go
DROP PROCEDURE [dbo].[sp_DeleteShop]
GO 