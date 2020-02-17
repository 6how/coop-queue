CREATE PROCEDURE [CoQ].[PostAddFriend] @UserID int, @FriendID int
AS

INSERT INTO CoQ.Friendships(FriendFromID, FriendToID, AddedOn, IsActive)
VALUES(@UserID, @FriendID, GETDATE(), 0)

DECLARE @NewRowID int
SET @NewRowID = SCOPE_IDENTITY()

SELECT 
	u.Id AS UserID,
	u.UserName,
	u.UserDescription,
	u.Email,
	i.ImageID,
	i.ImageName
FROM dbo.AspNetUsers u
JOIN CoQ.LikedGames lg ON lg.UserID = u.Id
JOIN CoQ.Image i ON i.ImageID = u.UserImageID
WHERE u.Id = @FriendID