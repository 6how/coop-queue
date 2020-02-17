create procedure CoQ.PostLikedGame @UserID int, @GameID int
as

INSERT INTO CoQ.LikedGames(GameID, UserID, LikedOn, IsActive)
VALUES(@GameID, @UserID, GETDATE(), 1)

SELECT TOP(1)
	g.GameID,
	g.GameName,
	g.GameDescription,
	i.ImageName,
	g.GameScore AS Score,
	gs.SystemName AS System
FROM CoQ.Games g
JOIN CoQ.Image i ON i.ImageID = g.GameImageID
JOIN GameSystem gs on gs.GameSystemID = g.GameSystemID