use SantaBelinda

-- =====================================================================================	|
-- ������� ����� �� �������� ��������������� �� ��������									|
-- =====================================================================================   \|/
go
create procedure SelectBySurname as
begin
	select p.ID, p.Surname, p.Name, p.Sex, p.DateOfBirth, p.DateD, p.Father, p.Mother
	from dbo.People as p
	where p.Surname IN( '�������', '�������', '���������', '�����' )
	order by p.Surname desc
end;

exec SelectBySurname



-- =====================================================================================	|
-- ������� 1.																				|
-- ������� ������� �� �������� ��������������� �� ��������									|
-- =====================================================================================   \|/
go
create procedure SelectOccupantBySurname as
begin
	select p.ID, p.Surname, p.Name, p.Sex, p.DateOfBirth, p.DateD, p.Father, p.Mother
	from dbo.People as p
	where p.ID IN(
		select occp.IdPeople
		from dbo.Occupant occp
	) and p.Surname IN( '�������', '�������', '���������', '�����', '����������' )
	order by p.Surname desc
end;

exec SelectOccupantBySurname



-- ================================================================================================		|
-- ������� 2.																							|
-- ������� ������� �� �������� �� ���������� ������� � ������� �������� ( ������� 1 )					|
-- ================================================================================================    \|/
go
create procedure SelectOccupantByAddressAndIn_ver1 as
begin
	select ppl.ID, ppl.Surname, ppl.Name, ppl.Sex, ppl.DateOfBirth, ppl.DateD, ppl.Father, ppl.Mother
	from dbo.People as ppl
	inner join
	dbo.Occupant occp on occp.IdPeople = ppl.ID
	inner join
	dbo.House hs on hs.ID = occp.IdHouse
	where ppl.Surname IN( '�������', '�������', '���������', '�����', '����������' ) and hs.Addres = '��.��������, 8' and
	occp.DateIn between '1985-01-01' and GETDATE()
end;

exec SelectOccupantByAddressAndIn_ver1



-- ================================================================================================		|
-- ������� 2.																							|
-- ������� ������� �� �������� �� ���������� ������� � ������� �������� ( ������� 2 )					|
-- ================================================================================================	   \|/
go
create procedure SelectOccupantByAddressAndIn_ver2 as
begin
	select ppl.ID, ppl.Surname, ppl.Name, ppl.Sex, ppl.DateOfBirth, ppl.DateD, ppl.Father, ppl.Mother
	from dbo.People as ppl
	where ppl.ID in(
		select occp.IdPeople
		from dbo.Occupant occp
		where occp.IdHouse in(
			select hs.ID
			from dbo.House hs
			where hs.Addres = '��.��������, 8'
		)
		and occp.DateIn between '1980-01-01' and GETDATE()
	)
	and ppl.Surname IN( '�������', '�������', '���������', '�����', '����������' )
end;

exec SelectOccupantByAddressAndIn_ver2



-- =====================================================================================	|
-- ������� 3.																				|
-- ������� ���������� ���������������� ( ��������  ���� ),									|
-- ������� ����� � ����� ������������ �������  ������� ����,								|
-- �������, ����������� � ������������ ���������� �������.									|
-- =====================================================================================   \|/
go
create procedure SelectCountBussinesMans as
begin
	select count(bs.IdPeople) as [���������� ����������������],
	avg(bs.Workmans) as [������� �-�� �������],
	min(bs.Workmans) as [����������� �-�� �������],
	max(bs.Workmans) as [������������ �-�� �������]
	from dbo.BusinessMans bs
	inner join
	dbo.People ppl on ppl.ID = bs.IdPeople
	where ppl.Sex = 0
end;

exec SelectCountBussinesMans



-- =====================================================================================	|
-- ������� 4.																				|
-- ������� ���������� �����, ����� ����� � ������� ������� ���� �������,					|
-- ������� �������� � ��������� ����														|
-- =====================================================================================   \|/
go
create procedure SelectCountHouse_AmountArea_AverageArea as
begin
	select count(hs.ID) as [�-�� �����], sum(hs.Area) as [����� �������],
	avg(hs.Area) as [������� �������]
	from dbo.House hs
	inner join
	dbo.Occupant occp on occp.IdHouse = hs.ID
	inner join
	dbo.People ppl on ppl.ID = occp.IdPeople
	where ppl.DateOfBirth >= '1900-01-01' and ppl.DateOfBirth <= '1999-12-31'
end;

exec SelectCountHouse_AmountArea_AverageArea



-- ================================================================================================		|
-- ������� 5.																							|
-- ������� �� �������� ������� ���� ������� ����������������.											|
-- ================================================================================================	   \|/
go
create procedure Select_Craft_and_Occupants_Address as
begin
	select crf.Name [�������], hs.Addres as [�����]
	from dbo.House hs
	inner join
	dbo.Occupant occp on occp.IdHouse = hs.ID
	inner join
	dbo.BusinessMans bm on bm.IdPeople = occp.IdPeople
	inner join
	dbo.Craft crf on crf.ID = bm.IdCraft
end;

exec Select_Craft_and_Occupants_Address

--select * from dbo.Craft
--select * from dbo.BusinessMans
--select * from dbo.House
--select * from dbo.Occupant
--select * from dbo.People