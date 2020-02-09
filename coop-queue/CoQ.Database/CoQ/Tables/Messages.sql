CREATE TABLE [CoQ].[Messages] (
    [MessageID]      INT            IDENTITY (1, 1) NOT NULL,
    [MessageContent] NVARCHAR (MAX) NOT NULL,
    [MessageFromID]  INT            NOT NULL,
    [MessageToID]    INT            NOT NULL,
    [MessageTime]    DATETIME       NOT NULL,
    [IsActive]       BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([MessageID] ASC),
    CONSTRAINT [FK_Messages_Users] FOREIGN KEY ([MessageFromID]) REFERENCES [CoQ].[Users] ([UserID]),
    CONSTRAINT [FK_Messages_Users1] FOREIGN KEY ([MessageToID]) REFERENCES [CoQ].[Users] ([UserID])
);



