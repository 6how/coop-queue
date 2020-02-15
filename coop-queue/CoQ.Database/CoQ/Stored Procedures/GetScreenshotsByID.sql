Create PROCEDURE CoQ.GetScreenshotsByID @GameID INT
	AS
SELECT * FROM CoQ.MediaLinks ml
WHERE ml.GameID = @GameID AND ml.LinkType LIKE '%Screenshot%' AND IsActive = 1