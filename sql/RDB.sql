--use RodonitCnrKSK
--declare 
--				@DataItogov datetime2(3),
--				--@TMC varbinary(16),
--				@Sclad varbinary(16),
--				@NaDatu datetime2(3)
--				SET @DataItogov = '5999-11-01 00:00:00';
--				--SET @TMC = 0xA0270015179D542F11DF4EBC9CEA2319;
--				SET @Sclad = ( SELECT _IDRRef FROM dbo._Reference54 WHERE _Fld791 = '   1BH   ' );
--				SET @NaDatu = '4018-11-11 23:59:59'
		
--		SELECT		
--			T5._Code as Code,
--			T5._Description AS NameNom,
--			T1.Fld2877Balance_	AS Kolichestvo
--		FROM ( SELECT
--			T2.Fld2874RRef AS Fld2875RRef,
--			T2.Fld2875RRef AS Fld2875RRef,
--			CAST( SUM( T2.Fld2877Balance_ ) AS NUMERIC( 38, 8 ) ) AS Fld2877Balance_
--		FROM ( SELECT
--			T3._Fld2875RRef AS Fld2875RRef,
--			T3._Fld2874RRef AS Fld2874RRef,
--			CAST( SUM( T3._Fld2877 ) AS NUMERIC( 32, 8 ) ) AS Fld2877Balance_
--		FROM 
--			_AccumRgT2881 AS T3 WITH( NOLOCK )
--		WHERE
--			T3._Period = @DataItogov AND ( ( ( T3._Fld2874RRef = @Sclad ) ) )
--		GROUP BY
--			T3._Fld2875RRef, T3._Fld2874RRef
--		HAVING ( CAST( SUM( T3._Fld2877 ) AS NUMERIC( 32, 8 ) ) ) <> 0

--		UNION ALL

--		SELECT
--			T4._Fld2875RRef AS Fld2875RRef,		-- Номенклатура
--			T4._Fld2874RRef AS Fld2874RRef,		-- Склад
--			CAST( CAST( SUM( CASE WHEN T4._RecordKind = 0.0 THEN -T4._Fld2877 ELSE T4._Fld2877 END ) AS NUMERIC( 26, 8 ) ) AS NUMERIC( 27, 3 ) ) AS Fld2877Balance_
--		FROM
--			_AccumRg2873 AS T4 WITH( NOLOCK )
--		WHERE
--			T4._Period >= @NaDatu AND T4._Period < @DataItogov AND T4._Active = 0x01 AND ( ( ( T4._Fld2874RRef = @Sclad ) ) )
--		GROUP BY
--			T4._Fld2875RRef, T4._Fld2874RRef
--		HAVING ( CAST( CAST( SUM( CASE WHEN T4._RecordKind = 0 THEN - T4._Fld2877 ELSE T4._Fld2877 END ) AS NUMERIC( 26, 8 ) ) AS NUMERIC( 27, 3 ) ) ) <> 0 ) as T2
--		GROUP BY
--			T2.Fld2874RRef, T2.Fld2874RRef
--		HAVING ( CAST( SUM( T2.Fld2877Balance_ ) AS NUMERIC( 38, 8 ) ) ) <> 0 ) AS T1
--		LEFT OUTER JOIN _Reference45 AS T5 WITH( NOLOCK ) ON T1.Fld2875RRef = T5._IDRRef
--		order by t5._Description asc


declare 
	@DataItogov datetime2(3),
	--@TMC varbinary(16),
	@Sclad varbinary(16),
	@NaDatu datetime2(3)
	SET @DataItogov = '5999-11-01 00:00:00';
	--SET @TMC = 0xA0270015179D542F11DF4EBC9CEA2319;
	SET @Sclad = ( SELECT _IDRRef FROM dbo._Reference54 WHERE _Fld791 = '   1BH   ' );
	SET @NaDatu = '4018-11-11 23:59:59'
	
SELECT
	--T1.t2_Fld2874RRef AS Склад,	
	--T1.t2_Fld2875RRef AS Номенклатура,
	T5._Code as Code,
	T5._Description AS NameNom,
	T1.t2_Fld2877Balance_ AS Количество

FROM (SELECT
	T2.t3_Fld2875RRef AS t2_Fld2875RRef,
	T2.t3_Fld2874RRef AS t2_Fld2874RRef,
	CAST(SUM(T2.Fld2877Balance_) AS NUMERIC(38, 8)) AS t2_Fld2877Balance_
FROM (SELECT
	T3._Fld2875RRef AS t3_Fld2875RRef,
	T3._Fld2874RRef AS t3_Fld2874RRef,
	CAST(SUM(T3._Fld2877) AS NUMERIC(32, 8)) AS Fld2877Balance_
	FROM
		_AccumRgT2881 AS T3 WITH(NOLOCK)
	WHERE
		T3._Period = @DataItogov AND (((T3._Fld2874RRef = @Sclad)))
	GROUP BY
		T3._Fld2875RRef, T3._Fld2874RRef
	HAVING (CAST(SUM(T3._Fld2877) AS NUMERIC(32, 8))) <> 0
		
UNION ALL 
		
SELECT
	T4._Fld2875RRef AS t4_Fld2875RRef,
	T4._Fld2874RRef AS t4_Fld2874RRef,
	CAST(CAST(SUM(CASE WHEN T4._RecordKind = 0.0 THEN -T4._Fld2877 ELSE T4._Fld2877 END ) AS NUMERIC( 26, 8 ) ) AS NUMERIC( 27, 3 ) ) AS t4_Fld2877Balance_
FROM
	_AccumRg2873 AS T4 WITH(NOLOCK)
WHERE
	T4._Period >= @NaDatu AND T4._Period < @DataItogov AND T4._Active = 0x01 AND (((T4._Fld2874RRef = @Sclad)))
GROUP BY
	T4._Fld2875RRef, T4._Fld2874RRef
HAVING (CAST(CAST(SUM(CASE WHEN T4._RecordKind = 0 THEN -T4._Fld2877 ELSE T4._Fld2877 END) AS NUMERIC(26, 8)) AS NUMERIC(27, 3))) <> 0) as T2
GROUP BY
	T2.t3_Fld2875RRef, T2.t3_Fld2874RRef
HAVING (CAST(SUM(T2.Fld2877Balance_) AS NUMERIC(38, 8))) <> 0) AS T1
		
LEFT OUTER JOIN _Reference42 AS T5 WITH(NOLOCK) ON T1.t2_Fld2875RRef = T5._IDRRef
order by t5._Description asc


SELECT * FROM dbo._Reference54



--================================================================================

declare @stock varbinary( 16 )	-------------------------------------------- Склад
select @stock = s._IDRRef from dbo._Reference54 s where s._Fld791 = '   1BH   '

select n._Code [ Код ], n._Description [ Номенклатура ], sum( tns._Fld2877 ) [ Количество ],
tns._Period [ Дата ]
from dbo._Reference45 n with( nolock )
inner join
dbo._AccumRg2873 tns on tns._Fld2875RRef = n._IDRRef
where tns._RecordKind = 0 and tns._Active = 0x01
and tns._Fld2874RRef = @stock --and tns._Period = '4018-11-01 23:59:59.000'
group by n._Code, n._Description, tns._Period

--================================================================================

declare @stock varbinary( 16 )	-------------------------------------------- Склад
select @stock = s._IDRRef from dbo._Reference54 s where s._Fld791 = '   1BH   '

select n._Code [ Код ], n._Description [ Номенклатура ], sum( tnsI._Fld2877 ) [ Количество ]
from dbo._Reference45 n with( nolock )
inner join
dbo._AccumRgT2881 tnsI on tnsI._Fld2875RRef = n._IDRRef
where tnsI._Fld2874RRef = @stock and tnsI._Period = '5999-11-01 00:00:00.000'
group by n._Code, n._Description

select * from dbo._AccumRgT2881 tnsI