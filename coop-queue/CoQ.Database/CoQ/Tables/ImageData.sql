CREATE TABLE [CoQ].[ImageData] (
    [ImageDataID] INT            IDENTITY (1, 1) NOT NULL,
    [ImageID]     INT            NOT NULL,
    [ContentType] NVARCHAR (MAX) NOT NULL,
    [IsActive]    BIT            NOT NULL
);

