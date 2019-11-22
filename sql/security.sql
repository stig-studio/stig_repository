-- ���������� ������
exec sp_addlogin 'User1', '1231'


-- �������� ������������
use Academy
create user User1


-- ���������� ���� ��� ������������
exec sp_addrolemember 'db_datareader','User1'


-- ��������� �������� ������
grant delete on Academy.dbo.Teachers to NewUser


-- ��������� �������������� ������
exec sp_addrole 'Editor'
grant insert, update,delete, select on Academy.dbo.Teachers to Editor
exec sp_addrolemember Editor, User1


-- �������� ����� �� Update
use Academy
deny update on Academy.dbo.Teachers to User1


-- ������ �������� ���� �� Update
use Academy
revoke update on Academy.dbo.Teachers to User1

-- �������� ������
drop login User1