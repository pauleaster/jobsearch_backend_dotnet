CREATE TABLE [dbo].[search_terms] (
    [term_id]     INT            IDENTITY (1, 1) NOT NULL,
    [old_term_id] INT            NULL,
    [term_text]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_search_terms] PRIMARY KEY CLUSTERED ([term_id] ASC)
);

