CREATE TABLE [CoQ].[Image] (
    [ImageID]   INT            IDENTITY (1, 1) NOT NULL,
    [ImageName] NVARCHAR (100) NOT NULL,
    [FileSize]  BIGINT         NULL,
    [IsActive]  BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ImageID] ASC)
);





