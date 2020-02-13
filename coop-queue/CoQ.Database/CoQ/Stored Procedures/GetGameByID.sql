CREATE PROCEDURE CoQ.GetGameByID @GameID int
	AS
SELECT TOP(1)
	g.GameID,
	g.GameName,
	g.GameScore,
	gs.SystemName AS GameSystem,
	g.IsActive
FROM CoQ.Games g
JOIN CoQ.GameSystem gs ON gs.GameSystemID = g.GameSystemID
WHERE g.GameID = 6