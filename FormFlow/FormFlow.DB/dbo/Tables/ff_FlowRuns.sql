CREATE TABLE [dbo].[ff_FlowRuns] (
    [ID]            UNIQUEIDENTIFIER NOT NULL,
    [StartedAt]     DATETIME         CONSTRAINT [DF_ff_FlowRuns_StartedAt] DEFAULT (getdate()) NULL,
    [CurrentStepID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_ff_FlowRuns] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ff_FlowRuns_ff_Steps] FOREIGN KEY ([CurrentStepID]) REFERENCES [dbo].[ff_Steps] ([ID])
);

