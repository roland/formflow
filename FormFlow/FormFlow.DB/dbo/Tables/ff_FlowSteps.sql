CREATE TABLE [dbo].[ff_FlowSteps] (
    [ID]         UNIQUEIDENTIFIER CONSTRAINT [DF_ff_FlowSteps_ID] DEFAULT (newid()) NOT NULL,
    [StepID]     UNIQUEIDENTIFIER NOT NULL,
    [FromStepID] UNIQUEIDENTIFIER NULL,
    [FlowRunID]  UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]  DATETIME         CONSTRAINT [DF_ff_FlowSteps_CreatedAt] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_ff_FlowSteps] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ff_FlowSteps_ff_FlowRuns] FOREIGN KEY ([FlowRunID]) REFERENCES [dbo].[ff_FlowRuns] ([ID]),
    CONSTRAINT [FK_ff_FlowSteps_ff_Steps] FOREIGN KEY ([StepID]) REFERENCES [dbo].[ff_Steps] ([ID]),
    CONSTRAINT [FK_ff_FlowSteps_ff_StepsFrom] FOREIGN KEY ([FromStepID]) REFERENCES [dbo].[ff_Steps] ([ID])
);

