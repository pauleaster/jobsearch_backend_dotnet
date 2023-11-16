CREATE TABLE [dbo].[search_term_id_mapping] (
    [term_id]     INT NOT NULL,
    [old_term_id] INT NULL,
    PRIMARY KEY CLUSTERED ([term_id] ASC)
);

