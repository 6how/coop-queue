CREATE PROCEDURE [CoQ].[GetFeedForUser] @UserID int
	AS

DECLARE @IsLiked bit = 0;

IF(OBJECT_ID('tempdb..#GamesToHide') IS NOT NULL)
	BEGIN
		DROP TABLE #GamesToHide
	END

CREATE TABLE #GamesToHide(
	GameID int
)

INSERT INTO #GamesToHide
SELECT 
	g.GameID
FROM CoQ.Games g
JOIN CoQ.LikedGames lg ON lg.GameID = g.GameID
WHERE lg.UserID = @UserID

INSERT INTO #GamesToHide
SELECT 
	g.GameID
FROM CoQ.Games g
JOIN CoQ.DislikedGames dg ON dg.GameID = g.GameID
WHERE dg.UserID = @UserID

SELECT
	g.GameID,
	g.GameName,
	g.GameDescription,
	i.ImageName,
	g.GameScore AS Score,
	gs.SystemName AS System
FROM coq.games g
LEFT OUTER JOIN CoQ.LikedGames lg ON lg.GameID = g.GameID
LEFT OUTER JOIN CoQ.DislikedGames dlg ON dlg.GameID = g.GameID
JOIN CoQ.GameSystem gs ON gs.GameSystemID = g.GameSystemID
JOIN CoQ.[Image] i ON i.ImageID = g.GameImageID
WHERE NOT EXISTS(SELECT 1 FROM #GamesToHide gth WHERE lg.GameID = gth.GameID) AND 
	NOT EXISTS(SELECT 1 FROM #GamesToHide gth WHERE dlg.GameID = gth.GameID)

IF(OBJECT_ID('tempdb..#GamesToHide') IS NOT NULL)
	BEGIN
		DROP TABLE #GamesToHide
	END