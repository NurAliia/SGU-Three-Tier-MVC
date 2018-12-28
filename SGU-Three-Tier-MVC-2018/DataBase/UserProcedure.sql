
CREATE PROCEDURE [dbo].[sp_InsertUser]   
	@Name nvarchar(50), 
    @LastName nvarchar(50),
	@Patronymic nvarchar(50),
	@EMail nvarchar(50),
	@Password binary(512),
	@Phone nvarchar(12)
	
AS
	SET NOCOUNT ON;
    INSERT INTO [dbo].[User] ([Name], LastName, Patronymic, EMail,[Password],Phone )
    VALUES ( @Name,@LastName,@Patronymic, @EMail, @Password, @Phone)
	DECLARE @IdUser INT
	Select @IdUser = IdUser From [dbo].[User] Where EMail = @EMail
	INSERT INTO UserRole (IdUser, IdRole)
	VALUES (@IdUser,3)     	
GO

CREATE PROCEDURE [dbo].[sp_City]
AS
	SELECT
	[dbo].[City].IDCity,
	[dbo].[City].[NameCity]
	FROM [dbo].[City] 
GO
CREATE PROCEDURE [dbo].[sp_GetUsers]
AS		
    SELECT 
	[dbo].[User].IdUser,
	[dbo].[User].[Name], 
	[dbo].[User].LastName, 
	[dbo].[User].Patronymic,
	[dbo].[User].EMail,
	[dbo].[User].Phone
	FROM [dbo].[User] 
GO



CREATE PROCEDURE [dbo].[sp_GetModerators]
AS		
    SELECT 
	[dbo].[User].IdUser,
	[dbo].[User].[Name], 
	[dbo].[User].LastName, 
	[dbo].[User].Patronymic,
	[dbo].[User].EMail,
	[dbo].[User].Phone
	FROM [dbo].[User] 
	JOIN [dbo].[UserRole] on [dbo].[UserRole].IDRole = 2
GO
CREATE PROCEDURE [dbo].[sp_GetUserByEMail]
	 @EMail nvarchar(50)
AS	
	SELECT 
	[dbo].[User].IDUser,
	[dbo].[User].[Name],
	[dbo].[User].LastName,
	[dbo].[User].Patronymic,
	[dbo].[User].EMail,
	[dbo].[User].Phone
	From [dbo].[User]
	Where Email = @EMail
GO

CREATE PROCEDURE [dbo].[sp_GetUserById]
	 @IDUser INT 
AS	
	SELECT 
	[dbo].[User].IdUser,
	[dbo].[User].[Name], 
	[dbo].[User].LastName, 
	[dbo].[User].Patronymic,
	[dbo].[User].EMail,
	[dbo].[User].Phone
	From [dbo].[User] Where IDUser = @IDUser
GO

CREATE PROCEDURE [dbo].[sp_UpdateUser]
	 @IDUser INT,
	 @Name nvarchar(50),
	 @LastName nvarchar(50),
	 @Patronymic nvarchar(50),
	 @EMail nvarchar(50),
	 @Password binary(512),
	 @Phone nvarchar(12)
AS
	UPDATE [dbo].[User] SET
	[Name]=@Name,
	LastName=@LastName,
	Patronymic=@Patronymic,
	EMail= @EMail,
	[Password]=@Password,
	Phone = @Phone
	Where IdUser = @IDUser
GO

CREATE PROCEDURE [dbo].[sp_GetUserRole]
	@IDUser INT
AS
	SELECT IdRole From UserRole Where IdUser = @IDUser
GO

CREATE	PROCEDURE [dbo].[sp_ChangeUserRole]
	@IDUser INT,
	@IDRole INT
AS
	UPDATE UserRole SET IdRole=@IDRole Where IdUser=@IDUser
Go

CREATE PROCEDURE [dbo].[sp_DeleteUser]
	 @IDUser int
AS
	DELETE FROM [dbo].[User] Where IdUser = @IDUser
GO 

--CREATE PROCEDURE [dbo].[sp_DeleteUniver]
--	 @IDUser int,
--	 @IDDirection int
--AS
--	DELETE FROM [dbo].[LinkUserUniver] Where (IdUser = @IDUser and IdDirection=@IDDirection)
--GO 

CREATE PROCEDURE [dbo].[sp_AddReaffirmationRight]
	 @IDUser int
AS
	INSERT INTO ReaffirmationRight VALUES(@IDUser)
GO 

CREATE PROCEDURE [dbo].[sp_GetReaffirmationRight]	 
AS
	SELECT 
	[dbo].[User].IdUser,
	[dbo].[User].[Name], 
	[dbo].[User].LastName, 
	[dbo].[User].Patronymic,
	[dbo].[User].EMail,
	[dbo].[User].Phone
	FROM ReaffirmationRight
	JOIN [dbo].[User] on [dbo].[User].IdUser = ReaffirmationRight.IdUser
GO 

CREATE PROCEDURE [dbo].[sp_DeleteReaffirmationRight]
	 @IDUser int
AS
	DELETE FROM ReaffirmationRight Where IdUser=@IDUser
	UPDATE UserRole SET IdRole=3 Where IdUser=@IDUser
GO 
CREATE PROCEDURE [dbo].[sp_UpdateUser]
	@IDUser int,
	@Name nvarchar(50), 
    @LastName nvarchar(50),
	@Patronymic nvarchar(50),
	@EMail nvarchar(50),
	@Phone nvarchar(12)
	
AS
	UPDATE [dbo].[User]
	SET 
	[Name]=@Name,
	LastName =@LastName,
	Patronymic=@Patronymic,
	EMail=@EMail,
	Phone=@Phone	
	Where IDUser=@IDUser	
GO

CREATE PROCEDURE [dbo].[sp_LoginUser]
	@Login NVARCHAR(50),
	@Password binary(512)
AS
	SELECT IDUser
	From [dbo].[User]
	Where 
	Email COLLATE Latin1_General_CS_AS =@Login
	and [Password] = @Password
GO


DROP PROCEDURE [sp_InsertUser]  
GO 
DROP PROCEDURE [sp_GetUsers]  
GO 
DROP PROCEDURE [dbo].[sp_GetModerators]
GO
DROP PROCEDURE [sp_GetUserByEMail]  
GO 
DROP PROCEDURE [dbo].[sp_GetUserById]
GO
DROP PROCEDURE [dbo].[sp_UpdateUser]
GO
DROP PROCEDURE [dbo].[sp_GetUserRole]
GO
DROP PROCEDURE [dbo].[sp_ChangeUserRole]
GO
DROP PROCEDURE [dbo].[sp_DeleteUser]
GO
DROP PROCEDURE [dbo].[sp_AddReaffirmationRight]
GO
Drop Procedure [dbo].[sp_GetReaffirmationRight]
GO
DROP PROCEDURE [dbo].[sp_DeleteReaffirmationRight]
Go
DROP PROCEDURE [sp_LoginUser]  
GO 