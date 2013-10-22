CREATE TABLE [dbo].[ff_Steps] (
    [ID]         UNIQUEIDENTIFIER CONSTRAINT [DF_ff_Steps_ID] DEFAULT (newid()) NOT NULL,
    [StepTypeID] UNIQUEIDENTIFIER NOT NULL,
    [FlowID]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ff_Steps] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ff_Steps_ff_Flows] FOREIGN KEY ([FlowID]) REFERENCES [dbo].[ff_Flows] ([ID]),
    CONSTRAINT [FK_ff_Steps_ff_StepTypes] FOREIGN KEY ([StepTypeID]) REFERENCES [dbo].[ff_StepTypes] ([ID])
);

