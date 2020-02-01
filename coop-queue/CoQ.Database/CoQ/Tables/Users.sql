CREATE TABLE [CoQ].[Users] (
    [UserID]          INT            IDENTITY (1, 1) NOT NULL,
    [UserName]        NVARCHAR (100) NOT NULL,
    [Email]           NVARCHAR (100) NOT NULL,
    [ImageID]         INT            NULL,
    [IsActive]        BIT            NOT NULL,
    [UserDescription] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);



