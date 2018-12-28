CREATE PROCEDURE [dbo].[sp_InsertComment]   
	@IDUser int, 
    @IDShop int,
	@Text nvarchar(445)
	
AS
	DECLARE @Date smalldatetime
	SET @Date =GETDATE()
	SET NOCOUNT ON;
    INSERT INTO	[dbo].[Comment] (IDUser, IDShop, [Text], [Date])
    VALUES ( @IDUser,@IDShop,@Text, @Date)	    	
GO

CREATE PROCEDURE [dbo].[sp_GetCommentsByAuthor]
	@Author INT
AS		
    SELECT 
	[dbo].[Comment].IDComment,
	[dbo].[Comment].IDUser,
	[dbo].[Comment].IDShop, 
	[dbo].[Comment].[Text], 
	[dbo].[Comment].[Date]
	FROM [dbo].[Comment] 
	WHere [dbo].[Comment].IDUser=@Author
GO

CREATE PROCEDURE [dbo].[sp_GetCommentsByShop]	
	@IDShop INT
AS	
    SELECT 
	[dbo].[Comment].IDComment,
	[dbo].[User].[Name],
	[dbo].[Comment].IDShop, 
	[dbo].[Comment].[Text], 
	[dbo].[Comment].[Date]
	FROM [dbo].[Comment] 
	JOIN [dbo].[User] on [dbo].[User].IDUser=[dbo].[Comment].IDUser	
	WHERE [dbo].[Comment].IDShop=@IDShop
GO

CREATE PROCEDURE [dbo].[sp_GetCommentsByDate]
	 @Date Datetime
AS	
	SELECT 
	[dbo].[Comment].IDComment,
	[dbo].[Comment].IDUser,
	[dbo].[Comment].IDShop, 
	[dbo].[Comment].[Text], 
	[dbo].[Comment].[Date]
	FROM [dbo].[Comment] 
	WHERE [dbo].[Comment].[Date]=@Date
GO

CREATE PROCEDURE [dbo].[sp_GetCommentById]
	 @IDComment Int
AS	
	SELECT 
	[dbo].[Comment].IDComment,
	[dbo].[Comment].IDUser,
	[dbo].[User].[Name],
	[dbo].[Comment].IDShop, 
	[dbo].[Comment].[Text], 
	[dbo].[Comment].[Date]
	FROM [dbo].[Comment] 
	JOIN [dbo].[User] on [dbo].[User].IDUser = [dbo].[Comment].IDUser
	WHERE [dbo].[Comment].IDComment=@IDComment
GO


CREATE PROCEDURE [dbo].[sp_UpdateComment]
	 @IDComment int,
	 @IDUser int,
	 @IDShop int,
	 @Text nvarchar(445),
	 @Date Datetime
AS
	UPDATE [dbo].[Comment] 
	SET
	IDUser=@IDUser,
	IDShop=@IDShop,
	[Text]= @Text,
	[Date]=@Date
	Where IDComment = @IDComment
GO


CREATE PROCEDURE [dbo].[sp_DeleteCommentById]
	 @IDComment int
AS
	DELETE FROM [dbo].[Comment] Where IDComment = @IDComment
GO 


DROP PROCEDURE [sp_InsertComment] 
GO 
DROP PROCEDURE [sp_GetCommentsByAuthor]
GO 
DROP PROCEDURE [sp_GetCommentsByShop]  
GO 
DROP PROCEDURE [sp_GetCommentsByDate]  
GO 
DROP PROCEDURE [dbo].[sp_GetCommentById]
GO
DROP PROCEDURE [dbo].[sp_UpdateComment]
Go
DROP PROCEDURE [dbo].[sp_DeleteCommentById]
GO 