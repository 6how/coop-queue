CREATE PROCEDURE [CoQ].[GetFriendsList]
	@UserID int
AS

IF(OBJECT_ID('tempdb..#FriendshipInfo') IS NOT NULL)
	BEGIN
		DROP TABLE #FriendshipInfo
	END
	
CREATE TABLE #FriendshipInfo(
	FriendshipID int,
	FriendFromID int,
	FriendToID int,
	AddedOn DATETIME
)

INSERT INTO #FriendshipInfo
SELECT 
	f.FriendshipID,
	f.FriendFromID AS FriendFromID,
	f.FriendToID AS FriendToID,
	f.AddedOn
FROM CoQ.Friendships f
WHERE (f.FriendFromID = @UserID OR f.FriendToID = @UserID) AND f.IsActive = 1

SELECT
	f.FriendshipID,
	f.FriendFromID AS FriendFromID,
	f.FriendToID AS FriendToID,
	f.AddedOn AS FriendAddedOn,
	u.UserName AS FriendName
FROM #FriendshipInfo f
LEFT JOIN CoQ.Users u ON (u.UserID = f.FriendFromID OR u.UserID = f.FriendToID)
WHERE u.UserID <> @UserID

IF(OBJECT_ID('tempdb..#FriendshipInfo') IS NOT NULL)
	BEGIN
		DROP TABLE #FriendshipInfo
	END