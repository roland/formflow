CREATE TABLE [dbo].[ff_StepTypes] (
    [ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_ff_StepTypes_ID] DEFAULT (newid()) NOT NULL,
    [Name] VARCHAR (100)    NULL,
    CONSTRAINT [PK_ff_StepTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

