CREATE PROCEDURE CoQ.GetFeedForUser @UserID int
	AS
SELECT
	g.GameID,
	g.GameName,
	g.GameScore,
	gs.SystemName--,
	--image
FROM coq.games g
LEFT OUTER JOIN CoQ.LikedGames lg ON lg.GameID = g.GameID
JOIN CoQ.GameSystem gs ON gs.GameSystemID = g.GameSystemID
WHERE(lg.UserID <> 1 OR lg.UserID IS NULL)