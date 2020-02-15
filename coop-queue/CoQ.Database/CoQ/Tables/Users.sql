CREATE TABLE [CoQ].[Users] (
    [UserID]               INT            IDENTITY (1, 1) NOT NULL,
    [UserName]             NVARCHAR (100) NOT NULL,
    [Email]                NVARCHAR (100) NOT NULL,
    [ImageID]              INT            NULL,
    [IsActive]             BIT            NOT NULL,
    [UserDescription]      NVARCHAR (MAX) NULL,
    [EmailConfirmed]       BIT            NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [Phonenumber]          INT            NULL,
    [PhoneNumberConfirmed] BIT            NULL,
    [TwoFactorEnabled]     BIT            NULL,
    [LockoutEnabled]       BIT            NULL,
    [LockoutEnd]           DATETIME       NULL,
    [AccessFailedCount]    INT            NULL,
    [UserImage]            IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_Image] FOREIGN KEY ([ImageID]) REFERENCES [CoQ].[Image] ([ImageID])
);





