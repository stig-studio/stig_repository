use master

-------------------------------------------------------------------------------------------------
-- ������� ���� � ����������� �����
-------------------------------------------------------------------------------------------------
alter database dbnew_centr
set single_user with rollback immediate
-------------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------------
-- ������������ ���� ������
-------------------------------------------------------------------------------------------------
exec sp_detach_db @dbname = N'dbnew_centr'
-------------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------------
-- ������������� ���� ������
-------------------------------------------------------------------------------------------------
exec sp_attach_db @dbname = N'dbnew_centr',
@filename1 = N'C:\SQLBase\dbnew_centr.mdf',
@filename2 = N'C:\SQLBase\dbnew_centr.ldf';
-------------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------------
-- ������� ���� � ��������������������� �����
-------------------------------------------------------------------------------------------------
alter database dbnew_centr
set multi_user
-------------------------------------------------------------------------------------------------