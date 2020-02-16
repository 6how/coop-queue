CREATE PROCEDURE [CoQ].PutAcceptFriend @UserID int, @FriendID int
AS

UPDATE CoQ.Friendships
SET IsActive = 1
WHERE ((FriendFromID = @UserID AND FriendToID = @FriendID) OR
	(FriendToID = @UserID AND FriendFromID = @FriendID)) AND IsActive = 0

DECLARE @RowID int
SET @RowID = SCOPE_IDENTITY()

SELECT 
	u.UserID,
	u.UserName,
	u.UserDescription,
	u.Email,
	u.IsActive,
	i.ImageID,
	i.ImageName
FROM CoQ.Users u
JOIN CoQ.LikedGames lg ON lg.UserID = u.UserID
JOIN CoQ.Image i ON i.ImageID = u.UserImageID
WHERE u.UserID = @FriendID