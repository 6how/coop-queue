CREATE TABLE [CoQ].[tempUsers] (
    [tempUserID]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]         NVARCHAR (100) NOT NULL,
    [Email]            NVARCHAR (150) NOT NULL,
    [IsActive]         BIT            NOT NULL,
    [ProfilePictureID] INT            NULL,
    PRIMARY KEY CLUSTERED ([tempUserID] ASC)
);

