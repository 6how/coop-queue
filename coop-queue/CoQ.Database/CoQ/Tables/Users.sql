CREATE TABLE [CoQ].[Users] (
    [UserID]               INT            IDENTITY (1, 1) NOT NULL,
    [UserName]             NVARCHAR (100) NOT NULL,
    [Email]                NVARCHAR (100) NOT NULL,
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
    [UserImageID]          INT            NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);









