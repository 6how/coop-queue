CREATE PROCEDURE [CoQ].[PutAcceptFriend] @UserID int, @FriendID int
AS

UPDATE CoQ.Friendships
SET IsActive = 1
WHERE ((FriendFromID = @UserID AND FriendToID = @FriendID) OR
	(FriendToID = @UserID AND FriendFromID = @FriendID)) AND IsActive = 0

DECLARE @RowID int
SET @RowID = SCOPE_IDENTITY()

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