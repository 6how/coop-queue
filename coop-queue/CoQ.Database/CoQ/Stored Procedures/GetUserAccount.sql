CREATE PROCEDURE CoQ.GetUserAccount
	@UserID int
AS

SELECT TOP(1)
	u.UserID,
	u.UserName,
	u.Email,
	u.UserDescription,
	i.ImageName,
	i.FileSize,
	ib.Blob,
	it.ImageTypeName

FROM CoQ.Users u
LEFT OUTER JOIN CoQ.[Image] i ON i.ImageID = u.ImageID
LEFT OUTER JOIN CoQ.ImageBlob ib on ib.ImageID = i.ImageID
LEFT OUTER JOIN CoQ.ImageType it on it.ImageTypeID = i.ImageTypeID

WHERE u.UserID = @UserID AND u.IsActive = 1