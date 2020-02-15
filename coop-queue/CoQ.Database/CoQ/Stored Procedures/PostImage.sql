CREATE PROCEDURE [CoQ].[PostImage] @UserID int, @ImageName nvarchar(100), @ImageSize int, @ImageBase64 varchar(max), @ContentType nvarchar(max)
	AS

--Deactivates old ImageID
DECLARE @OldImage int
SET @OldImage = 
(SELECT TOP(1) UserImageID FROM CoQ.Users 
WHERE UserID = @UserID)

UPDATE CoQ.Image
SET IsActive = 0
WHERE ImageID = @OldImage

--Adds new image
INSERT INTO CoQ.[Image](ImageName, FileSize, IsActive)
VALUES(@ImageName, @ImageSize, 1)

DECLARE @ImageID int
SET @ImageID = SCOPE_IDENTITY()

INSERT INTO CoQ.ImageBase64String(Base64String, ImageID, IsActive)
VALUES(@ImageBase64, @ImageID, 1)

INSERT INTO CoQ.ImageData(ImageID, ContentType, IsActive)
VALUES(@ImageID, @ContentType, 1)

--Updates the user's image
UPDATE CoQ.Users
SET UserImageID = @ImageID
WHERE UserID = @UserID

--Returns the new image
SELECT TOP (1)
	i.ImageID,
	i.FileSize,
	i.ImageName AS Name,
	ib.Base64String,
	id.ContentType
FROM CoQ.[Image] i
JOIN CoQ.ImageBase64String ib ON i.ImageID = ib.ImageID
JOIN CoQ.ImageData id ON i.ImageID = id.ImageID
WHERE i.ImageID = @ImageID AND i.IsActive = 1