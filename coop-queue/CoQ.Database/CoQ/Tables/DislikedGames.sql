CREATE TABLE [CoQ].[DislikedGames] (
    [DislikedGameID] INT      IDENTITY (1, 1) NOT NULL,
    [GameID]         INT      NOT NULL,
    [UserID]         INT      NOT NULL,
    [DislikedOn]     DATETIME NOT NULL,
    [IsActive]       BIT      NOT NULL
);

