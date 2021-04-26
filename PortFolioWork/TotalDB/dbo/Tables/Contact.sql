CREATE TABLE [dbo].[Contact] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)  NOT NULL,
    [Email]    VARCHAR (125)  NOT NULL,
    [Contents] NVARCHAR (MAX) NOT NULL,
    [RegDate]  DATETIME       NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC)
);

