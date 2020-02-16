CREATE TABLE [CoQ].[Friendships] (
    [FriendshipID] INT      IDENTITY (1, 1) NOT NULL,
    [FriendFromID] INT      NOT NULL,
    [FriendToID]   INT      NOT NULL,
    [AddedOn]      DATETIME NOT NULL,
    [IsActive]     BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([FriendshipID] ASC)
);





