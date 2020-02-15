Create PROCEDURE CoQ.GetReviewsByID @GameID INT
	AS
SELECT * FROM CoQ.MediaLinks ml
WHERE ml.GameID = @GameID AND ml.LinkType LIKE '%Review%' AND IsActive = 1