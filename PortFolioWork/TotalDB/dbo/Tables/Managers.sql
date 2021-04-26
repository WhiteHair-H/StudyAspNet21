CREATE TABLE [dbo].[Managers] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Cate]     VARCHAR (10)   NOT NULL,
    [Subject]  NVARCHAR (20)  NOT NULL,
    [Contents] NVARCHAR (MAX) NOT NULL,
    [RegDate]  DATETIME       NULL,
    CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

