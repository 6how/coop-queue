CREATE PROCEDURE [CoQ].[GetFriendsList]
	@UserID int
AS

SELECT 
	f.FriendFromID AS Sender,
	f.FriendToID AS Recipient,
	f.AddedOn AS AddedDate,
	u.UserName AS UserName
FROM CoQ.Friendships f
JOIN CoQ.Users u ON u.UserID = f.FriendFromID
JOIN CoQ.Users ON u.UserID = f.FriendToID
WHERE f.FriendFromID = @UserID AND f.FriendToID = @UserID AND u.IsActive = 1 AND f.IsActive = 1