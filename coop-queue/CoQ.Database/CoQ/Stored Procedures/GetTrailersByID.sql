Create PROCEDURE CoQ.GetTrailersByID @GameID INT
	AS
SELECT * FROM CoQ.MediaLinks ml
WHERE ml.GameID = @GameID AND ml.LinkType LIKE '%Trailer%' AND IsActive = 1