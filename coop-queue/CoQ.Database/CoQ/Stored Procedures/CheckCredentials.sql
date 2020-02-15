CREATE procedure 
CoQ.CheckCredentials 
	@EmailAddress nvarchar(max),
	@Password nvarchar(max)
AS

SELECT TOP(1)
	u.UserID,
	u.Email AS EmailAddress
FROM CoQ.Users u
WHERE u.Email = @EmailAddress AND u.PasswordHash = @Password AND u.IsActive = 1