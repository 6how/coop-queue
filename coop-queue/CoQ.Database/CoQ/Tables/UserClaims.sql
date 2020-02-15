CREATE TABLE [CoQ].[UserClaims] (
    [UserClaimsID] INT           NOT NULL,
    [UserID]       INT           NOT NULL,
    [ClaimType]    NVARCHAR (50) NOT NULL,
    [ClaimValue]   NVARCHAR (50) NOT NULL
);

