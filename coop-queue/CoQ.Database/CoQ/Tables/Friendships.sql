CREATE TABLE [CoQ].[Friendships] (
    [FriendshipID] INT      IDENTITY (1, 1) NOT NULL,
    [FriendFromID] INT      NOT NULL,
    [FriendToID]   INT      NOT NULL,
    [AddedOn]      DATETIME NOT NULL,
    [IsActive]     BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([FriendshipID] ASC),
    CONSTRAINT [FK_Friendships_Users] FOREIGN KEY ([FriendFromID]) REFERENCES [CoQ].[Users] ([UserID]),
    CONSTRAINT [FK_Friendships_Users1] FOREIGN KEY ([FriendToID]) REFERENCES [CoQ].[Users] ([UserID])
);



