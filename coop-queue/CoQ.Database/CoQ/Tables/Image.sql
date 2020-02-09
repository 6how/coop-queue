CREATE TABLE [CoQ].[Image] (
    [ImageID]     INT            IDENTITY (1, 1) NOT NULL,
    [ImageTypeID] INT            NOT NULL,
    [ImageName]   NVARCHAR (100) NOT NULL,
    [FileSize]    BIGINT         NULL,
    [IsActive]    BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ImageID] ASC),
    CONSTRAINT [FK_Image_ImageType] FOREIGN KEY ([ImageTypeID]) REFERENCES [CoQ].[ImageType] ([ImageTypeID])
);



