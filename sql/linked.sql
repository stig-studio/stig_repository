exec sp_addlinkedserver @server='SQL1'
--exec sp_addlinkedserver @server='SQL2014'

EXEC sp_addlinkedsrvlogin 'SQL1', 'false', NULL, 'user', 'pass'
select * from SQL1.dbcopy1.dbo.sc204

select * from Univer1.dbo.Lecture
cross join SQL1.dbcopy1.dbo.sc204


