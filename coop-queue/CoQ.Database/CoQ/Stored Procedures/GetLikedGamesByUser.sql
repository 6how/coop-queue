CREATE PROCEDURE [CoQ].[GetLikedGamesByUser] 
	@UserID int
AS

SELECT 
	lg.LikedGameID AS LikedGameID,
	g.GameID,
	g.GameName AS GameName,
	i.ImageName,
	ibs.Base64String AS GameImagePath,
	g.GameScore AS Score,
	gs.SystemName AS [System],
	lg.LikedOn AS LikedOn
FROM CoQ.LikedGames lg
JOIN CoQ.Games g ON g.GameID = lg.GameID
JOIN CoQ.Image i ON i.ImageID = g.GameImageID
JOIN CoQ.ImageBase64String ibs ON ibs.ImageID = g.GameImageID
JOIN CoQ.GameSystem gs on g.GameSystemID = gs.GameSystemID
WHERE lg.UserID = @UserID AND lg.IsActive = 1 AND g.IsActive = 1