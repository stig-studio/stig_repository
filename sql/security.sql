-- Добавление логина
exec sp_addlogin 'User1', '1231'


-- Создание пользователя
use Academy
create user User1


-- Добавление роли для пользователя
exec sp_addrolemember 'db_datareader','User1'


-- Разрешить удаление данных
grant delete on Academy.dbo.Teachers to NewUser


-- Разрешить редактирование данных
exec sp_addrole 'Editor'
grant insert, update,delete, select on Academy.dbo.Teachers to Editor
exec sp_addrolemember Editor, User1


-- Удаление права на Update
use Academy
deny update on Academy.dbo.Teachers to User1


-- Отмена удаления прав на Update
use Academy
revoke update on Academy.dbo.Teachers to User1

-- Удаление логина
drop login User1