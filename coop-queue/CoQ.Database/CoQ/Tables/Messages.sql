CREATE TABLE [CoQ].[Messages] (
    [MessageID]      INT            IDENTITY (1, 1) NOT NULL,
    [MessageContent] NVARCHAR (MAX) NOT NULL,
    [MessageFromID]  INT            NOT NULL,
    [MessageToID]    INT            NOT NULL,
    [MessageTime]    DATETIME       NOT NULL,
    [IsActive]       BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([MessageID] ASC)
);





