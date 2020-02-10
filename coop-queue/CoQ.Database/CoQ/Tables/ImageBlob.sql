﻿CREATE TABLE [CoQ].[ImageBlob] (
    [ImageBlobID] INT             IDENTITY (1, 1) NOT NULL,
    [ImageID]     INT             NOT NULL,
    [Blob]        VARBINARY (MAX) NOT NULL,
    [IsActive]    BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ImageBlobID] ASC),
    CONSTRAINT [FK_ImageBlob_Image] FOREIGN KEY ([ImageID]) REFERENCES [CoQ].[Image] ([ImageID])
);


