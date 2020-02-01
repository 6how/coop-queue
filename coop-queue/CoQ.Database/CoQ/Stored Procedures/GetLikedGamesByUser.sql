CREATE PROCEDURE CoQ.[GetLikedGamesByUser] 
	@UserID int
AS

SELECT 
	g.GameName AS GameName,
	g.GameScore AS Score,
	gs.SystemName AS [System],
	lg.LikedOn AS LikedOn
FROM CoQ.LikedGames lg
JOIN CoQ.Games g ON g.GameID = lg.GameID
JOIN CoQ.GameSystem gs on g.GameSystemID = gs.GameSystemID 
WHERE lg.UserID = @UserID AND lg.IsActive = 1 AND g.IsActive = 1