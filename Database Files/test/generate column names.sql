use heartyhealthdb

declare @tablename VARCHAR(50)= 'recipe'
select 
concat('@', c.COLUMN_NAME, ' ', c.DATA_TYPE, ' ', 
case when c.CHARACTER_MAXIMUM_LENGTH is null then '' else  CONCAT('(', c.CHARACTER_MAXIMUM_LENGTH, ')') end, 
case when c.TABLE_NAME + 'ID' = c.COLUMN_NAME then ' output' else '' end, 
 ',') 
from information_schema.columns c 
where c.table_name = @tablename

DECLARE @insertlist VARCHAR(5000)= ''
SELECT 
@insertlist= @insertlist + CONCAT(c.COLUMN_NAME, ', ')
from information_schema.columns c 
where c.table_name = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'ID'
SELECT @insertlist

SELECT @insertlist = ''


SELECT 
@insertlist= @insertlist + CONCAT('@', c.COLUMN_NAME, ', ')
from information_schema.columns c 
where c.table_name = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'ID'
SELECT @insertlist


SELECT @insertlist = ''
SELECT 
@insertlist= @insertlist + CONCAT(c.COLUMN_NAME, '= ' ,  '@', c.COLUMN_NAME, ', ')
from information_schema.columns c 
where c.table_name = @tablename
and c.COLUMN_NAME <> c.TABLE_NAME + 'ID'
SELECT @insertlist