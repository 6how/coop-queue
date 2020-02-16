CREATE PROCEDURE [CoQ].[GetUserAccount]
	@UserID int
AS

SELECT TOP(1)
	u.Id AS UserID,
	u.UserName,
	u.Email,
	u.UserDescription,
	i.ImageID,
	i.ImageName,
	i.FileSize,
	ib.Base64String,
	it.ContentType

FROM dbo.AspNetUsers u
LEFT OUTER JOIN CoQ.[Image] i ON i.ImageID = u.UserImageID
LEFT OUTER JOIN CoQ.ImageBase64String ib on ib.ImageID = i.ImageID
LEFT OUTER JOIN CoQ.ImageData it on it.ImageID = i.ImageID

WHERE u.Id = @UserID