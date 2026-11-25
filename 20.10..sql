create view Datadictionary
as
select 
d.TABLE_NAME
, d.column_name
, iif(d.is_nullable = 'NO', '+', '-') required 
, d.data_type
, isnull(d.column_default, '') [DEFAULT]
from INFORMATION_SCHEMA.COLUMNS as d inner join
	INFORMATION_SCHEMA.TABLES as b on d.TABLE_NAME = b.TABLE_NAME
where (b.TABLE_TYPE = 'BASE TABLE')