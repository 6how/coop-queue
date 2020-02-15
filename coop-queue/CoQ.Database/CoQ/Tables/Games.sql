CREATE TABLE [CoQ].[Games] (
    [GameID]          INT            IDENTITY (1, 1) NOT NULL,
    [GameName]        NVARCHAR (100) NOT NULL,
    [GameScore]       INT            NULL,
    [GameSystemID]    INT            NOT NULL,
    [GameImageID]     INT            NULL,
    [IsActive]        BIT            NOT NULL,
    [GameDescription] VARCHAR (MAX)  NULL,
    PRIMARY KEY CLUSTERED ([GameID] ASC),
    CONSTRAINT [FK_Games_GameSystem] FOREIGN KEY ([GameSystemID]) REFERENCES [CoQ].[GameSystem] ([GameSystemID]),
    CONSTRAINT [FK_Games_Image] FOREIGN KEY ([GameImageID]) REFERENCES [CoQ].[Image] ([ImageID])
);





