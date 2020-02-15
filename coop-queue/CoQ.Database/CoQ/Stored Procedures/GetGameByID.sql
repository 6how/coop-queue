CREATE PROCEDURE [CoQ].[GetGameByID] @GameID int
	AS
SELECT TOP(1)
	g.GameID,
	g.GameName,
	g.GameDescription,
	i.ImageName,
	g.GameScore AS Score,
	gs.SystemName AS System
FROM CoQ.Games g
JOIN CoQ.GameSystem gs ON gs.GameSystemID = g.GameSystemID
JOIN CoQ.Image i ON i.ImageID = g.GameImageID
WHERE g.GameID = @GameID