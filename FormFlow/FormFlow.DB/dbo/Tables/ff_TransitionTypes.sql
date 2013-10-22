CREATE TABLE [dbo].[ff_TransitionTypes] (
    [ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_ff_TransitionTypes_ID] DEFAULT (newid()) NOT NULL,
    [Name] VARCHAR (100)    NOT NULL,
    CONSTRAINT [PK_ff_TransitionTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

