CREATE PROCEDURE [CoQ].[AddUserFromTempUsers]
	@tempUserID int
AS

INSERT INTO CoQ.Users(UserID, UserName, Email, ImageID, IsActive)
SELECT TOP(1) *
FROM CoQ.tempUsers tu
WHERE tu.tempUserID = 1 AND IsActive = 1