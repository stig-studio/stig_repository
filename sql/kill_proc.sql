declare @dbname sysname 
set @dbname = 'BuchPosad'

--���� ����� ������
select spid from sysprocesses
where dbid = db_id(@dbname)
and spid > 50

--����� ��������� ������� kill
kill --����� ��������� ����� ������(�������� kill 62)