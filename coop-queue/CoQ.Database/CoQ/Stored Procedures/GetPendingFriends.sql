CREATE PROCEDURE [CoQ].[GetPendingFriends]
	@UserID int
AS

IF(OBJECT_ID('tempdb..#PendingFriendInfo') IS NOT NULL)
	BEGIN
		DROP TABLE #PendingFriendInfo
	END
CREATE TABLE #PendingFriendInfo(
	FriendshipID int,
	FriendFromID int,
	FriendToID int,
	AddedOn DATETIME
)

INSERT INTO #PendingFriendInfo
SELECT 
	f.FriendshipID,
	f.FriendFromID AS FriendFromID,
	f.FriendToID AS FriendToID,
	f.AddedOn
FROM CoQ.Friendships f
WHERE (f.FriendFromID = @UserID OR f.FriendToID = @UserID) AND f.IsActive = 0

SELECT
	f.FriendshipID,
	f.FriendFromID AS FriendFromID,
	f.FriendToID AS FriendToID,
	f.AddedOn AS FriendAddedOn,
	i.ImageName AS FriendImageName,
	u.UserName AS FriendName,
	u.Id AS OtherFriendID,
	ibs.Base64String AS FriendImagePath
FROM #PendingFriendInfo f
LEFT JOIN dbo.AspNetUsers u ON (u.Id = f.FriendFromID OR u.Id = f.FriendToID)
JOIN CoQ.Image i ON u.UserImageID = i.ImageID
JOIN CoQ.ImageBase64String ibs ON u.UserImageID = ibs.ImageID
WHERE u.Id <> @UserID

IF(OBJECT_ID('tempdb..#PendingFriendInfo') IS NOT NULL)
	BEGIN
		DROP TABLE #PendingFriendInfo
	END