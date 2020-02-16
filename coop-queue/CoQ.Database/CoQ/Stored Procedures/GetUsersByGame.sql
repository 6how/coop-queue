CREATE PROCEDURE CoQ.GetUsersByGame @GameID int, @UserID int
	AS

--THIS SHOULD CHANGE TO REMOVE PEOPLE YOU ARE ALREADY FRIENDS WITH BUT I AM DUMB SO I CANT RN
SELECT 
	u.UserID,
	u.UserName,
	u.UserDescription,
	u.Email,
	u.IsActive,
	i.ImageID,
	i.ImageName
FROM CoQ.Users u
JOIN CoQ.LikedGames lg ON lg.UserID = u.UserID
JOIN CoQ.Image i ON i.ImageID = u.UserImageID
WHERE lg.UserID <> @UserID AND lg.GameID = @GameID