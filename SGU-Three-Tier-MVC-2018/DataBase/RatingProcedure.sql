CREATE PROCEDURE [dbo].[sp_InsertRating]   
	@IDShop int, 
	@IDUser int,
	@Grade int	
AS
	SET NOCOUNT ON;
    INSERT INTO [dbo].[Rating] (IDShop, IDUser,Rating)
    VALUES ( @IDShop,@IDUser,@Grade)
GO

CREATE PROCEDURE [dbo].[sp_GetRatingShopById]
	 @IDShop INT
AS	
	SELECT AVG(Rating) as avrRating
	FROM [dbo].[Rating] 	
	Where [dbo].[Rating].IDShop = @IDShop
GO
CREATE PROCEDURE [dbo].[sp_GetRatingByShop]
	 @IDShop INT
AS	
	SELECT 
	[dbo].[Rating].IDShop,
	[dbo].[Rating].IDUser,
	[dbo].[Rating].Rating
	FROM [dbo].[Rating] 	
	Where [dbo].[Rating].IDShop = @IDShop
GO



DROP PROCEDURE [sp_InsertRating] 
GO 
DROP PROCEDURE [dbo].[sp_GetRatingShopById]
GO
DROP PROCEDURE [sp_GetRatingByShop]
GO 