CREATE PROCEDURE [CoQ].[GetFriendsList]
	@UserID int
AS

SELECT 
	f.FriendshipID,	
	f.FriendFromID AS FriendFromID,
	f.FriendToID AS FriendToID,
	f.AddedOn AS FriendAddedOn
FROM CoQ.Friendships f
WHERE (f.FriendFromID = @UserID OR f.FriendToID = @UserID) AND f.IsActive = 1