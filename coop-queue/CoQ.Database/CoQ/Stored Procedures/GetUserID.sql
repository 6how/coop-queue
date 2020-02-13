CREATE PROCEDURE CoQ.GetUserID 
	@EmailAddress nvarchar(max)
AS

SELECT TOP(1)
	u.UserID
FROM CoQ.Users u

WHERE u.Email = @EmailAddress