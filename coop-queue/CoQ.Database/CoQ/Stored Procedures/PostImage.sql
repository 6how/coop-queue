CREATE PROCEDURE [CoQ].[PostImage] @ImageName nvarchar(100), @ImageSize int, @ImageBase64 varchar(max), @ContentType nvarchar(max)
	AS

INSERT INTO CoQ.[Image](ImageName, FileSize, IsActive)
VALUES(@ImageName, @ImageSize, 1)

DECLARE @ImageID int
SET @ImageID = SCOPE_IDENTITY()

INSERT INTO CoQ.ImageBase64String(Base64String, ImageID, IsActive)
VALUES(@ImageBase64, @ImageID, 1)

INSERT INTO CoQ.ImageData(ImageID, ContentType, IsActive)
VALUES(@ImageID, @ContentType, 1)

SELECT TOP (1)
	i.ImageID,
	i.FileSize,
	i.ImageName AS Name,
	ib.Base64String,
	id.ContentType
FROM CoQ.[Image] i
JOIN CoQ.ImageBase64String ib ON i.ImageID = ib.ImageID
JOIN CoQ.ImageData id ON i.ImageID = id.ImageID
WHERE i.ImageID = @ImageID