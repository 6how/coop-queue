CREATE PROCEDURE CoQ.PostAddFriend @UserID int, @FriendID int
AS

INSERT INTO CoQ.Friendships(FriendFromID, FriendToID, AddedOn, IsActive)
VALUES(@UserID, @FriendID, GETDATE(), 0)

DECLARE @NewRowID int
SET @NewRowID = SCOPE_IDENTITY()

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