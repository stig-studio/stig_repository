
USE master

-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

-- ���������� ������������ �������
EXEC sp_addlogin @loginame = N'db_school_journal_select', @passwd = N'192837465', @defdb = N'SchoolMagaz'

-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

-- ��������� ������������ ���� �� ������ �������
EXEC sp_addsrvrolemember @loginame='db_school_journal_select', @rolename='dbcreator'

-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

USE SchoolMagaz

-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

EXEC sp_grantdbaccess 'db_school_journal_select'

-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

-- �������� ����
EXEC sp_addrole @rolename='db_school_journal_select_role'
EXEC sp_addrolemember @rolename='db_school_journal_select_role', @membername = 'db_school_journal_select'

-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

GRANT SELECT
ON Users
TO db_school_journal_select