CREATE PROCEDURE [CoQ].[GetUsersByGame] @GameID int, @UserID int
	AS

--THIS SHOULD CHANGE TO REMOVE PEOPLE YOU ARE ALREADY FRIENDS WITH BUT I AM DUMB SO I CANT RN
SELECT 
	u.Id AS UserID,
	u.UserName,
	u.UserDescription,
	u.Email,
	i.ImageID,
	i.ImageName
FROM dbo.AspNetUsers u
JOIN CoQ.LikedGames lg ON lg.UserID = u.Id
LEFT OUTER JOIN CoQ.Image i ON i.ImageID = u.UserImageID
WHERE lg.UserID <> @UserID AND lg.GameID = @GameID