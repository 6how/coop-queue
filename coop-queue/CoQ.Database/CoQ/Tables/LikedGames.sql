CREATE TABLE [CoQ].[LikedGames] (
    [LikedGameID] INT      IDENTITY (1, 1) NOT NULL,
    [GameID]      INT      NOT NULL,
    [UserID]      INT      NOT NULL,
    [LikedOn]     DATETIME NOT NULL,
    [IsActive]    BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([LikedGameID] ASC),
    CONSTRAINT [FK_LikedGames_Games] FOREIGN KEY ([GameID]) REFERENCES [CoQ].[Games] ([GameID]),
    CONSTRAINT [FK_LikedGames_Users] FOREIGN KEY ([UserID]) REFERENCES [CoQ].[Users] ([UserID])
);



