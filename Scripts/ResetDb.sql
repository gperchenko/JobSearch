use JobSearch

DECLARE @sql nvarchar(max) = '';

-- Build the DROP TABLE statements for all tables in dbo schema
SELECT @sql = @sql + 'DROP TABLE dbo.' + QUOTENAME(t.name) + ';'
FROM sys.tables t
WHERE t.type = 'U' AND t.schema_id = SCHEMA_ID('dbo');

-- Execute the constructed DROP TABLE statements
EXEC sp_executesql @sql;