CREATE TABLE [dbo].[Boards] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Subject]   NVARCHAR (250) NOT NULL,
    [Contents]  NVARCHAR (MAX) NULL,
    [Writer]    NVARCHAR (25)  NOT NULL,
    [RegDate]   DATETIME       NULL,
    [ReadCount] INT            NULL,
    CONSTRAINT [PK_Boards] PRIMARY KEY CLUSTERED ([Id] ASC)
);

