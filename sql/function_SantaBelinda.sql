use SantaBelinda;

-- =====================================================================================	|
-- Задание 1.																				|
-- Выборка жильцев по фамилиям отсортированных по убыванию									|
-- =====================================================================================   \|/
go
create function Select_occupant_by_surname(@var_name1 nvarchar(20), @var_name2 nvarchar(20))
returns table
as
return(
	select p.ID, p.Name, p.Surname
	from dbo.People p
	where p.Surname IN(@var_name1, @var_name2)
)

select * from Select_occupant_by_surname(N'Иванов', N'Никольский')


-- ================================================================================================		|
-- Задание 2.																							|
-- Выборка жильцев по фамилиям по указанному адрессу в заданый интервал                					|
-- ================================================================================================    \|/
go
create function occupants_by_addr_and_by_interval( @var_surname1 nvarchar(20), 
@var_surname2 nvarchar(20), @var_addr nvarchar(30), @interval_from date, @interval_to date )
returns table
as
return (
	select ppl.ID, ppl.Surname, ppl.Name, ppl.Sex, ppl.DateOfBirth, ppl.DateD, ppl.Father, ppl.Mother
	from dbo.People as ppl
	inner join
	dbo.Occupant occp on occp.IdPeople = ppl.ID
	inner join
	dbo.House hs on hs.ID = occp.IdHouse
	where ppl.Surname IN( @var_surname1, @var_surname2 ) and hs.Addres = @var_addr and
	occp.DateIn between @interval_from and @interval_to
)

select * from occupants_by_addr_and_by_interval('Якольский', 'Никольский', 'ул.Кленовая, 8', '1985-01-01', getdate())


-- =====================================================================================	|
-- Задание 3.																				|
-- Выборка количества предпринимателей ( мужского  пола ),									|
-- которые имеют в своем распоряжении наемную  рабочую силу,								|
-- среднее, минимальное и максимальное количество человек.									|
-- =====================================================================================   \|/
go
create function count_bussinessman(@var_sex int)
returns table
as
return(
	select count(bs.IdPeople) as [Количество предпринимателей],
	avg(bs.Workmans) as [Среднее к-во человек],
	min(bs.Workmans) as [Минимальное к-во человек],
	max(bs.Workmans) as [Максимальное к-во человек]
	from dbo.BusinessMans bs
	inner join
	dbo.People ppl on ppl.ID = bs.IdPeople
	where ppl.Sex = @var_sex
)

select * from count_bussinessman(0)


-- =====================================================================================	|
-- Задание 4.																				|
-- Выборка количества домов, общую сумму и среднюю площадь всех жителей,					|
-- которые родились в двадцатом веке														|
-- =====================================================================================   \|/
go
create function count_home_sum_area(@interval_from date, @interval_to date)
returns table
as
return(
	select count(hs.ID) as [К-во домов], sum(hs.Area) as [Общая площадь],
	avg(hs.Area) as [Средняя площадь]
	from dbo.House hs
	inner join
	dbo.Occupant occp on occp.IdHouse = hs.ID
	inner join
	dbo.People ppl on ppl.ID = occp.IdPeople
	where ppl.DateOfBirth >= @interval_from and ppl.DateOfBirth <= @interval_to
)

select * from count_home_sum_area('1900-01-01', '1999-12-31')


-- ================================================================================================		|
-- Задание 5.																							|
-- Выборка по названию ремесла всех адресов предпринимателей.											|
-- ================================================================================================	   \|/

go
create function select_craft()
returns table
as
return(
	select crf.Name [Ремесло], hs.Addres as [Адрес]
	from dbo.House hs
	inner join
	dbo.Occupant occp on occp.IdHouse = hs.ID
	inner join
	dbo.BusinessMans bm on bm.IdPeople = occp.IdPeople
	inner join
	dbo.Craft crf on crf.ID = bm.IdCraft
)

select * from select_craft()