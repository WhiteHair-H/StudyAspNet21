CREATE TABLE [dbo].[Users] (
    [UID]      INT           IDENTITY (1, 1) NOT NULL,
    [UserID]   NVARCHAR (25) NOT NULL,
    [Password] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([UID] ASC)
);

