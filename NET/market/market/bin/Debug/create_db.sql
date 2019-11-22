
-- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

use master

go
create database market on (
	name = market,
	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\market.mdf',
	size = 10,
	maxsize = 50,
	filegrowth = 5
)
log on(
	name = BookShop_log,
	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\market_log.ldf',
	size = 5MB,
	maxsize = 25MB,
	filegrowth = 5MB
);


-- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

use market

-- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

create table products (

	id int identity primary key not null,
	name nvarchar( 50 ) not null,
	price smallmoney not null,
	real_price smallmoney not null,
	barcode nvarchar( 13 ) not null

)

-- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

create table sale (
	
	id int identity primary key not null,
	dt_sale datetime not null,

)

-- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

create table sale_products (

	id int identity primary key not null,
	id_sale int foreign key references sale( id ) not null,
	id_product int foreign key references products( id ) not null,
	count_products int not null

)

create table balance (
	
	id int identity primary key not null,
	id_product int foreign key references products( id ),
	count_products int not null,
	delivery_date date not null

)

-- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
use market

go
create trigger Check_Client_data
on sale_products for insert
as
begin
	
	declare @id_prod int
	declare @count int
	set @count = 0

	select @id_prod = i.id_product from inserted i
	select @count = i.count_products from inserted i

	update dbo.balance
		set
			count_products = count_products - @count
		where
			id_product = @id_prod

	if( ( select b.count_products from dbo.balance b where id_product = @id_prod ) = 0 )
	begin
		delete from dbo.balance
		where count_products = 0
	end

end

-- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

insert into dbo.sale values( getdate() )

declare @id_sale int

select top 1 @id_sale = s.id from dbo.sale s order by s.dt_sale desc

insert into dbo.sale_products values( @id_sale, '', 0 )
