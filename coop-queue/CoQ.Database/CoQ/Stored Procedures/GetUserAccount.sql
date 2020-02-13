CREATE PROCEDURE [CoQ].[GetUserAccount]
	@UserID int
AS

SELECT TOP(1)
	u.UserID,
	u.UserName,
	u.Email,
	u.UserDescription,
	i.ImageName,
	i.FileSize,
	ib.Base64String,
	it.ContentType

FROM CoQ.Users u
LEFT OUTER JOIN CoQ.[Image] i ON i.ImageID = u.ImageID
LEFT OUTER JOIN CoQ.ImageBase64String ib on ib.ImageID = i.ImageID
LEFT OUTER JOIN CoQ.ImageData it on it.ImageID = i.ImageID

WHERE u.UserID = @UserID AND u.IsActive = 1