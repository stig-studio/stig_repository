use master

/*���������� ������������ �������*/
exec sp_addlogin @loginame='market_select', @passwd='1122334455', @defdb='market'

/*��������� ������������ ���� �� ������ �������*/
exec sp_addsrvrolemember @loginame='market_select', @rolename='dbcreator'

use market

exec sp_grantdbaccess 'market_select'

/*�������� ����*/
exec sp_addrole @rolename='market_select_role'
exec sp_addrolemember @rolename='market_select_role', @membername = 'market_select'

grant select
on products
to market_select

grant select
on balance
to market_select

grant select
on sale
to market_select

grant insert, update
on balance
to market_select

grant insert, update
on sale
to market_select

grant insert, update
on sale_products
to market_select