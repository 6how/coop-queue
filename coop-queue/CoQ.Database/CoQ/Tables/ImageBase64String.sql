CREATE TABLE [CoQ].[ImageBase64String] (
    [ImageBaseID]  INT           IDENTITY (1, 1) NOT NULL,
    [ImageID]      INT           NOT NULL,
    [Base64String] VARCHAR (MAX) NOT NULL,
    [IsActive]     BIT           NOT NULL
);

