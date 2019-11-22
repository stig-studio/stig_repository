
	USE dbnew

	DECLARE @inv_start_date	NVARCHAR( 14 )
	DECLARE @inv_end_date	NVARCHAR( 14 )
	DECLARE @min_date		DATE
		
	SET @inv_start_date	= ( CONVERT( NVARCHAR, CAST( '27.08.19' AS DATE ), 112 ) + '     0' )
	SET @inv_end_date	= ( CONVERT( NVARCHAR, CAST( '27.08.19' AS DATE ), 112 ) + 'EAEAY8' )
		
	-- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
	
	IF OBJECT_ID( 'tempdb..#source' ) IS NOT NULL
		DROP TABLE #source
	
	-- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
		
	CREATE TABLE #source (
	
		stock		CHAR( 9 ),
		startdate	DATE
	)
	
	-- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
	
	INSERT INTO #source( stock, startdate )
	
	SELECT
		s.ID,
		(
			SELECT
				( CONVERT( VARCHAR, CAST( LEFT( MAX( jrn.DATE_TIME_IDDOC ), 8 ) AS DATE ), 104 ) ) dt
			FROM dbo.DH5919 doc( NOLOCK )
			INNER JOIN
				dbo._1SJOURN jrn( NOLOCK ) ON jrn.IDDOC = doc.IDDOC
			WHERE
				doc.IDDOC <> d.IDDOC AND doc.SP5901 = d.SP5901 AND j.ISMARK = 0
		) startdate
	FROM dbo.SC204 s( NOLOCK )
	INNER JOIN
		dbo.DH5919 d( NOLOCK ) ON RIGHT( d.SP5901, 9 ) = s.ID
	INNER JOIN
		dbo._1SJOURN j( NOLOCK ) ON j.IDDOC = d.IDDOC
	WHERE
		j.ISMARK = 0 AND j.DATE_TIME_IDDOC BETWEEN @inv_start_date AND @inv_end_date AND s.SP17630 = 1
	
	-- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
	
	SELECT @min_date = MIN( s.startdate ) FROM #source s
	
	SELECT CONVERT( VARCHAR, @min_date, 104 )
	
	-- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
	
	DECLARE @mark_end_date DATETIME
	
	SET @mark_end_date	= ( CAST( '27.08.19' AS DATETIME ) )
	
	SELECT
		r.stock, r.startdate, r.employee, r.d_arrival, r.t_arrival, r.d_departure, r.t_departure,
		(
		CASE WHEN r.t_dp_minutes > r.t_ar_minutes THEN r.t_dp_minutes - r.t_ar_minutes
		ELSE r.t_ar_minutes - r.t_dp_minutes END ) sum_minute
	FROM (
		SELECT
			r.stock,
			r.startdate,
			r.employee,
			r.d_arrival,
			(
			CASE
				WHEN ( ( r.d_arrival = r.startdate ) AND CAST( LEFT( r.t_arrival, 2 ) AS INT ) < 17 ) THEN NULL
				WHEN ( ( r.d_arrival = @mark_end_date ) AND CAST( LEFT( r.t_arrival, 2 ) AS INT ) > 17 ) THEN NULL
				ELSE r.t_arrival
			END
			) t_arrival,
			r.d_departure,
			r.t_departure,
			r.t_ar_minutes,
			r.t_dp_minutes
		FROM (
			SELECT
				sk.DESCR stock,
				CONVERT( VARCHAR, s.startdate , 104 ) startdate,
				e.DESCR employee,
				CONVERT( VARCHAR, ud.SP15679, 104 ) d_arrival,
				CONVERT( VARCHAR( 5 ), ( DATEADD( MINUTE, ud.SP15680, 0 ) ), 108 ) t_arrival,
				CONVERT( VARCHAR, ud.SP15682, 104 ) d_departure,
				CONVERT( VARCHAR( 5 ), ( DATEADD( MINUTE, ud.SP15681, 0 ) ), 108 ) t_departure,
				ud.SP15680 t_ar_minutes,
				ud.SP15681 t_dp_minutes
			FROM dbo.SC204 sk( NOLOCK )
			INNER JOIN
				#source s ON s.stock = sk.ID
			INNER JOIN
				dbo.SC15684 ud( NOLOCK ) ON ud.SP18616 = s.stock
			INNER JOIN
				dbo.SC258 e( NOLOCK ) ON e.ID = ud.PARENTEXT
			WHERE
				ud.ISMARK = 0 AND ud.SP15679 BETWEEN CAST( s.startdate AS DATETIME ) AND @mark_end_date
		) r
	) r
	WHERE
		r.t_arrival IS NOT NULL
	ORDER BY
		r.stock, r.employee, r.d_arrival
	
	-- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
	DROP TABLE #source