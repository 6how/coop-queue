CREATE TABLE [CoQ].[GameSystem] (
    [GameSystemID] INT            IDENTITY (1, 1) NOT NULL,
    [SystemName]   NVARCHAR (100) NULL,
    [IsActive]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([GameSystemID] ASC)
);

