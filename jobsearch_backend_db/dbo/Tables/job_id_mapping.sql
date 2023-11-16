CREATE TABLE [dbo].[job_id_mapping] (
    [job_id]     INT NOT NULL,
    [old_job_id] INT NULL,
    PRIMARY KEY CLUSTERED ([job_id] ASC)
);

