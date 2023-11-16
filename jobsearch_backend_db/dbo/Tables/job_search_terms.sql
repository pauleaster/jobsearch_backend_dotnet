CREATE TABLE [dbo].[job_search_terms] (
    [old_job_id]  INT      NULL,
    [old_term_id] SMALLINT NULL,
    [job_id]      INT      NOT NULL,
    [term_id]     INT      NOT NULL,
    [valid]       BIT      NOT NULL,
    CONSTRAINT [PK_job_search_terms] PRIMARY KEY CLUSTERED ([job_id] ASC, [term_id] ASC)
);

