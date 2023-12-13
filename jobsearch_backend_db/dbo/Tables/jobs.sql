CREATE TABLE [dbo].[jobs] (
    [job_id]               INT            IDENTITY (1, 1) NOT NULL,
    [old_job_id]           INT            NULL,
    [job_number]           INT            NOT NULL,
    [job_url]              TEXT           NOT NULL,
    [title]                TEXT           NULL,
    [comments]             TEXT           NULL,
    [requirements]         TEXT           NULL,
    [follow_up]            TEXT           NULL,
    [highlight]            TEXT           NULL,
    [applied]              TEXT           NULL,
    [contact]              TEXT           NULL,
    [application_comments] TEXT           NULL,
    CONSTRAINT [PK_jobs] PRIMARY KEY CLUSTERED ([job_id] ASC)
);

