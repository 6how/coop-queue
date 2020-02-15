CREATE PROCEDURE CoQ.GetNewsByID @GameID INT
	AS
SELECT * FROM CoQ.MediaLinks ml
WHERE ml.GameID = @GameID AND ml.LinkType LIKE '%News%' AND IsActive = 1