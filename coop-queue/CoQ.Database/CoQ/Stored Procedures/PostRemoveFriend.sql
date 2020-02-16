CREATE PROCEDURE [CoQ].[PostRemoveFriend] @UserID INT, @FriendID INT
	AS

UPDATE CoQ.Friendships
SET IsActive = 0
WHERE ((FriendFromID = @UserID AND FriendToID = @FriendID) OR
	(FriendToID = @UserID AND FriendFromID = @FriendID)) AND IsActive = 1

SELECT TOP(1) 
	f.FriendshipID,
	f.FriendFromID AS FriendFromID,
	f.FriendToID AS FriendToID,
	f.AddedOn AS FriendAddedOn,
	i.ImageName AS FriendImageName,
	u.UserName AS FriendName,
	u.UserID AS OtherFriendID,
	ibs.Base64String AS FriendImagePath
	FROM CoQ.Friendships f
LEFT JOIN CoQ.Users u ON (u.UserID = f.FriendFromID OR u.UserID = f.FriendToID)
JOIN CoQ.Image i ON u.UserImageID = i.ImageID
JOIN CoQ.ImageBase64String ibs ON u.UserImageID = ibs.ImageID
WHERE ((FriendFromID = @UserID AND FriendToID = @FriendID) OR
	(FriendToID = @UserID AND FriendFromID = @FriendID)) AND f.IsActive = 0