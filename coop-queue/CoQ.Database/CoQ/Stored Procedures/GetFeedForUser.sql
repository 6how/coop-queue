CREATE PROCEDURE [CoQ].[GetFeedForUser] @UserID int
	AS
SELECT
	g.GameID,
	g.GameName,
	g.GameDescription,
	i.ImageName,
	g.GameScore AS Score,
	gs.SystemName AS System
FROM coq.games g
LEFT OUTER JOIN CoQ.LikedGames lg ON lg.GameID = g.GameID
JOIN CoQ.GameSystem gs ON gs.GameSystemID = g.GameSystemID
JOIN CoQ.[Image] i ON i.ImageID = g.GameImageID
WHERE(lg.UserID <> 1 OR lg.UserID IS NULL)