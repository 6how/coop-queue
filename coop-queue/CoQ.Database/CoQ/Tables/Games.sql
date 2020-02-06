CREATE TABLE [CoQ].[Games] (
    [GameID]       INT            IDENTITY (1, 1) NOT NULL,
    [GameName]     NVARCHAR (100) NOT NULL,
    [GameScore]    INT            NULL,
    [GameSystemID] INT            NOT NULL,
    [GameImageID]  INT            NULL,
    [IsActive]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([GameID] ASC)
);

