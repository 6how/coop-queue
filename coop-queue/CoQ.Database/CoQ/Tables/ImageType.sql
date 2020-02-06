CREATE TABLE [CoQ].[ImageType] (
    [ImageTypeID]   INT           IDENTITY (1, 1) NOT NULL,
    [ImageTypeName] NVARCHAR (50) NOT NULL,
    [IsActive]      BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ImageTypeID] ASC)
);

