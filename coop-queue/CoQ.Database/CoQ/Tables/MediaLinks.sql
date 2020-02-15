CREATE TABLE [CoQ].[MediaLinks] (
    [MediaLinkID] INT           IDENTITY (1, 1) NOT NULL,
    [MediaURL]    VARCHAR (MAX) NOT NULL,
    [IsActive]    BIT           NOT NULL,
    [GameID]      INT           NULL,
    [LinkType]    VARCHAR (50)  NULL,
    CONSTRAINT [PK_MediaLinks] PRIMARY KEY CLUSTERED ([MediaLinkID] ASC)
);

