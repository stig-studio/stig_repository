declare @dbname sysname 
set @dbname = 'BuchPosad'

--ищем номер сессии
select spid from sysprocesses
where dbid = db_id(@dbname)
and spid > 50

--далее выполянем команду kill
kill --здесь указываем номер сессии(например kill 62)