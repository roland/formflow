CREATE TABLE [dbo].[ff_Transitions] (
    [ID]               UNIQUEIDENTIFIER CONSTRAINT [DF_ff_Transitions_ID] DEFAULT (newid()) NOT NULL,
    [Description]      VARCHAR (100)    NULL,
    [FromStepID]       UNIQUEIDENTIFIER NOT NULL,
    [ToStepID]         UNIQUEIDENTIFIER NULL,
    [TranistionTypeID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ff_Transitions] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ff_Transitions_ff_StepsFrom] FOREIGN KEY ([FromStepID]) REFERENCES [dbo].[ff_Steps] ([ID]),
    CONSTRAINT [FK_ff_Transitions_ff_TransitionsTo] FOREIGN KEY ([ToStepID]) REFERENCES [dbo].[ff_Steps] ([ID]),
    CONSTRAINT [FK_ff_Transitions_ff_TransitionTypes] FOREIGN KEY ([TranistionTypeID]) REFERENCES [dbo].[ff_TransitionTypes] ([ID])
);

