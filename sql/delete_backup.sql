DECLARE @DeleteDate nvarchar(50)
DECLARE @DeleteDateTime datetime
SET @DeleteDateTime = DateAdd(hh, -0, GetDate()-21)
SET @DeleteDate = (Select Replace(Convert(nvarchar, @DeleteDateTime, 111), '/', '-') + 'T' + Convert(nvarchar, @DeleteDateTime, 108))
EXECUTE master.dbo.xp_delete_file 0, N'D:\Backup_SQL\',N'bak', @DeleteDate, 1